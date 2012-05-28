using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core;
using System.Data.SqlServerCe;
using SFASystem.Pocket.Utils;
using System.IO;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.App.Code
{
    public class SyncErrorEventArgs : EventArgs
    {
        Exception exceptionObject;

        public Exception ExceptionObject
        {
            get { return exceptionObject; }
        }

        public SyncErrorEventArgs(Exception ex)
        {
            this.exceptionObject = ex;
        }
    }
    public class SyncComplEventArgs : EventArgs
    {
        SynchronizationResult result;
        public SynchronizationResult SynchronizationResult
        {
            get { return result; }
        }
        public SyncComplEventArgs(SynchronizationResult res)
        {
            this.result = res;
        }
    }
    public class SyncProgressEventArgs : EventArgs
    {
        private int progress;

        /// <summary>
        ///	Constructor.
        /// </summary>
        /// <param name="progress">The percent progress, from 0 to 100.</param>
        public SyncProgressEventArgs(int progress)
        {
            this.progress = progress;
        }

        /// <summary>
        ///	Gets the percent complete, from 0 to 100.
        /// </summary>
        public int Progress
        {
            get { return progress; }
        }
    }
    public enum SynchronizationResult
    {
        Success,
        Cancelled,
        Failed
    }

    public class SynchronizationManager : Singleton<SynchronizationManager>
    {
        #region Events
        public event EventHandler<EventArgs> SynchronizationStarted;
        public event EventHandler<SyncComplEventArgs> SynchronizationCompleted;
        public event EventHandler<SyncErrorEventArgs> SynchronizationError;
        public event EventHandler<SyncProgressEventArgs> SynchronizationProgress;
        #endregion

        private SqlCeReplication replication = new SqlCeReplication();
        private bool isSynchronizing = false;
        private bool isInitialized = false;
        /// <summary>
        /// Asynch result
        /// </summary>
        private IAsyncResult asyncResult;

        //private string filter = String.Empty;
        //private string internetUrl = string.Empty;
        //string internetLogin = string.Empty;
        //string internetPassword = string.Empty;

        //private string publisherName = string.Empty;
        //private string publisherDatabase = string.Empty;
        //private string subscriptionName = string.Empty;
        //private string publicationName = string.Empty;
        //string publisherLogin = string.Empty;
        //string publisherPassword = string.Empty;
        public bool DatabaseExists
        {
            get
            {
                return File.Exists(Settings.DatabaseFile);
            }
        }

        public void PerformSynchronization()
        {
            try
            {
                if (!isInitialized)
                    Initialize();

                //jesli baza nie istenije, tworzy subskrypcję
                if (!File.Exists(Settings.DatabaseFile))
                {
                    replication.AddSubscription(AddOption.CreateDatabase);
                }
                //synchronizacja
                OnSyncStarted();
                replication.Synchronize();
                OnSyncCompleted(new SyncComplEventArgs(SynchronizationResult.Success));
            }
            catch (Exception ex)
            {
                OnSyncError(ex);
            }
        }

        public void PerformAsyncSynchronization()
        {
            if (this.isSynchronizing)
            {
                return;
            }
            if (!isInitialized)
                Initialize();

            this.isSynchronizing = true;
            try
            {
                //jesli baza nie istenije, tworzy subskrypcję
                if (!File.Exists(Settings.DatabaseFile))
                {
                    replication.AddSubscription(AddOption.CreateDatabase);
                }
                OnSyncStarted();
                //synchronizacja
                this.asyncResult = replication.BeginSynchronize(
                    new AsyncCallback(SyncCompletedCallback),
                    null,
                    null,
                    new OnSynchronization(OnSynchronizationCallback),
                    replication);
                
            }
            catch (Exception ex)
            {
                OnSyncError(ex);
            }
        }

        /// <summary>
        /// Call this method to cancel the synchronize from the client.
        /// </summary>
        public void CancelSynchronize()
        {
            try
            {
                this.isSynchronizing = false;
                replication.CancelSynchronize();

                OnSyncCompleted(new SyncComplEventArgs(SynchronizationResult.Cancelled));
            }
            catch (Exception ex)
            {
                LogHelper.Error("Cannot cancel synchronization "+ex.Message);
                throw new Exception("Cannot cancel synchronization");
            }
        }

        /// <summary>
        /// Notifies about synchronization end
        /// </summary>
        /// <param name="ar"></param>
        private void SyncCompletedCallback(IAsyncResult ar)
        {
            this.isSynchronizing = false;
            SyncComplEventArgs sychResultArg;

            try
            {
                //Get synchronization result
                SqlCeReplication replication = (SqlCeReplication)ar.AsyncState;
                replication.EndSynchronize(ar);
                replication.SaveProperties();
                replication = null;

                //this.SaveSuccessfulSychInfo();

                sychResultArg = new SyncComplEventArgs(SynchronizationResult.Success);
            }
            catch (Exception ex)
            {
                LogHelper.Error("Synchronization failed\n" + ex.Message + "\n" + ex.StackTrace);
                UIHelper.ShowError("Synchronization failed\n" + ex.Message + "\n");
                sychResultArg = new SyncComplEventArgs(SynchronizationResult.Failed);
            }
            finally
            {
                this.isSynchronizing = false;
            }

            OnSyncCompleted(sychResultArg);
        }

        /// <summary>
        /// Method call while synchronizing.
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="percentComplete"></param>
        private void OnSynchronizationCallback(IAsyncResult ar, int percentComplete)
        {
            if (SynchronizationProgress != null)
                SynchronizationProgress(this, new SyncProgressEventArgs(percentComplete));
        }
        private void OnSyncStarted()
        {
            if (SynchronizationStarted != null)
                SynchronizationStarted(null, null);
        }

        private void OnSyncCompleted(SyncComplEventArgs eventArgs)
        {
            if (SynchronizationCompleted != null)
                SynchronizationCompleted(null, eventArgs);
        }

        private void OnSyncError(Exception ex)
        {
            if (SynchronizationError != null)
                SynchronizationError(null, new SyncErrorEventArgs(ex));
        }

        public void Initialize()
        {
            replication = new SqlCeReplication();
            replication.InternetUrl = @"http://192.168.1.1/SFAMobile/sqlcesa35.dll";
            replication.Publisher = "TOMMY-PC";
            replication.PublisherDatabase = "SFASystem";
            replication.PublisherSecurityMode = SecurityType.DBAuthentication;
            replication.PublisherLogin = "sfasystemuser";
            replication.PublisherPassword = "sfasystemuser";
            replication.Publication = "SFASystem";
            replication.HostName = DataManager.Instance.CurrentEmployeeID.ToString();
            replication.Subscriber = "SFASystemSubscriber";
            replication.SubscriberConnectionString = "Data Source=\"" + Settings.DatabaseFile + "\";Password=\"sfasystem\";Encrypt=true";
            isInitialized = true;
        }

        public SynchronizationManager()
        {
            
        }
    }
}
