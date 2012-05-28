using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.App.Code;
using System.Threading;

namespace SFASystem.Pocket.App.Controls
{
    public partial class SynchroControl : UserControl
    {
        public event EventHandler<EventArgs> SynchroEnds;
        public void OnSynchroEnds()
        {
            if (SynchroEnds != null)
                SynchroEnds(null, null);
        }

        private EventHandler<SyncComplEventArgs> synchCompletedHandler;
        private EventHandler<SyncErrorEventArgs> synchErrorHandler;
        private EventHandler<SyncProgressEventArgs> synchProgressHandler;
        private EventHandler<EventArgs> synchStartedHandler;

        public SynchroControl()
        {
            InitializeComponent();
            synchCompletedHandler = new EventHandler<SyncComplEventArgs>(Instance_SynchronizationCompleted);
            synchErrorHandler = new EventHandler<SyncErrorEventArgs>(Instance_SynchronizationError);
            synchProgressHandler = new EventHandler<SyncProgressEventArgs>(Instance_SynchronizationProgress);
            synchStartedHandler = new EventHandler<EventArgs>(Instance_SynchronizationStarted);
            
        }

        private void ClearHandlers()
        {
            SynchronizationManager.Instance.SynchronizationCompleted -= synchCompletedHandler;
            SynchronizationManager.Instance.SynchronizationError -= synchErrorHandler;
            SynchronizationManager.Instance.SynchronizationProgress -= synchProgressHandler;
            SynchronizationManager.Instance.SynchronizationStarted -= synchStartedHandler;
        }
        private void AssignHandlers()
        {
            SynchronizationManager.Instance.SynchronizationCompleted += synchCompletedHandler;
            SynchronizationManager.Instance.SynchronizationError += synchErrorHandler;
            SynchronizationManager.Instance.SynchronizationProgress += synchProgressHandler;
            SynchronizationManager.Instance.SynchronizationStarted += synchStartedHandler;
        }

        void Instance_SynchronizationStarted(object sender, EventArgs e)
        {
            //SwitchSyncUIEffects(true);
        }

        public void SynchroStart()
        {
            AssignHandlers();
            SynchronizationManager.Instance.PerformAsyncSynchronization();
            //Thread syncThread = new Thread(RDAManager.Instance.PerformAsyncSynchronization);
            //syncThread.Start();
        }

        void Instance_SynchronizationProgress(object sender, SyncProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler<SyncProgressEventArgs>(Instance_SynchronizationProgress), sender, e);
            }
            else
            {
                synchroProgress.Value = e.Progress;
            }
        }

        void Instance_SynchronizationCompleted(object sender, SyncComplEventArgs e)
        {
            //this.SwitchSyncUIEffects(false);
            ClearHandlers();
            if (e.SynchronizationResult == SynchronizationResult.Success)
                UIHelper.ShowInfo("Synchronizacja zakończona pomyślnie.");
            else if (e.SynchronizationResult == SynchronizationResult.Failed)
                UIHelper.ShowError("Błąd synchronizacji");
            else if (e.SynchronizationResult == SynchronizationResult.Cancelled)
                UIHelper.ShowInfo("Synchronizacja anulowana.");
            OnSynchroEnds();
        }

        void Instance_SynchronizationError(object sender, SyncErrorEventArgs e)
        {
            //this.SwitchSyncUIEffects(false);
            ClearHandlers();
            UIHelper.ShowError("Błąd podczas synchronizacji. " + e.ExceptionObject.Message);
            OnSynchroEnds();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SynchronizationManager.Instance.CancelSynchronize();
        }
    }
}
