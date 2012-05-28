/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;
using System.Configuration;
namespace SFASystem.Domain
{
	public class Repository : IDisposable
	{
		private static ISessionFactory factory;
		private static LocalDataStoreSlot mysessions;
		private ISession session;
		private ITransaction transaction;
		private IInterceptor interceptor;
		private bool isSessionCreator;
		public ISession Session
		{
			get{return this.session;}
		}
		public bool IsSessionCreator
		{
			get{return this.isSessionCreator;}
		}
		public bool IsOpen
		{
			get{return Repository.GetIsOpen(session);}
		}
		/// <summary>
		/// Static constructor creates a new session factory used by all instances
		/// of this class.
		/// </summary>
		static Repository()
		{
			Configuration cfg = new Configuration();
			cfg.AddAssembly("SFASystem.Domain");
			factory = cfg.BuildSessionFactory();
			mysessions =  Thread.AllocateDataSlot();
		}
		/// <summary>
		/// Initialized a new instance of the Repository class.
		/// </summary>
		public Repository()
		{
			this.isSessionCreator = true;
		}
		/// <summary>
		/// Initialized a new instance of the Repository class.
		/// </summary>
		/// <param name="interceptor">An instance of IInterceptor used to
		/// provide persistence pipeline processing on all persistent
		/// objects pass through it.</param>
		public Repository(IInterceptor interceptor) : this()
		{
			this.interceptor = interceptor;
		}
		/// <summary>
		/// Initialized a new instance of the Repository class.
		/// </summary>
		/// <param name="session">An instance of NHibernate.ISession that
		/// will be used as the default session by the gateway.</param>
		/// <remarks>
		/// <param name="interceptor">An instance of IInterceptor used to
		/// provide persistence pipeline processing on all persistent
		/// objects pass through it.</param>
		public Repository(ISession session, IInterceptor interceptor)
		{
			if (!Repository.GetIsOpen(session))
			{
				throw new Exception(String.Format("A {0} can only be constructed with an open session.", this.GetType().ToString()));
			}
			this.session = session;
			this.interceptor = interceptor;
		}
		/// <summary>
		/// Initialized a new instance of the Repository class.
		/// </summary>
		/// <param name="session">An instance of NHibernate.ISession that
		/// will be used as the default session by the gateway.</param>
		/// <remarks>
		public Repository(ISession session)
		{
			if (!Repository.GetIsOpen(session))
			{
				throw new Exception(String.Format("A {0} can only be constructed with an open session.", this.GetType().ToString()));
			}
			this.session = session;
		}
		static public void TEnd()
		{
			Thread.SetData(mysessions, null);
		}
		static public Repository TRepository()
		{
			if (Thread.GetData(mysessions) == null)
				Thread.SetData(mysessions, new Repository());
			return Thread.GetData(mysessions) as Repository;
		}
		static public ISession TSession()
		{
			Repository r = TRepository();
			r.Open();
			return r.Session;
		}
		/// <summary>
		/// Opens the gateway.
		/// </summary>
		/// <returns>
		/// True is gateway was already open.
		/// </returns>
		/// <remarks>
		/// Gateway is open when session is open and connection is open.
		/// </remarks>
		public bool Open()
		{
			if (!this.isSessionCreator)
			{
				throw new Exception("A gateway that is sharing the session of another gateway cannot be openned directly.");
			}
			bool wasOpen = true;
			if (this.session == null || !this.session.IsOpen)
			{
				wasOpen = false;
				if (this.interceptor != null)
				{
					this.session = factory.OpenSession(this.interceptor);
				}
				else
				{
					this.session = factory.OpenSession();
				}
			}
			// Session is open, connection could be either open or closed.
			// If connection is closed, open it. Indicate that session was
			// open.
			if (!this.session.IsConnected)
			{
				wasOpen = false;
				this.session.Reconnect();
			}
			return wasOpen;
		}
		public void Close()
		{
			if (!this.isSessionCreator)
			{
				throw new Exception("A gateway that is sharing the session of another gateway cannot be closed directly.");
			}
			if (this.session == null)
			{
				return;
			}
			if (this.session.IsConnected)
			{
				this.session.Disconnect();
			}
			if (this.session.IsOpen)
			{
				this.session.Close();
			}
		}
		public void BeginTransaction()
		{
			if (!this.isSessionCreator)
			{
				throw new Exception("A gateway that is sharing the session of another gateway cannot start a transaction on the shared session.");
			}
			if (!this.IsOpen)
			{
				throw new InvalidOperationException("Repository must be open before a transaction can be started on the gateway.");
			}
			if (this.transaction == null)
			{
				this.transaction = this.session.BeginTransaction();
			}
		}
		public void CommitTransaction()
		{
			if (!this.isSessionCreator)
			{
				throw new Exception("A gateway that is sharing the session of another gateway cannot commit a transaction on the shared session.");
			}
			if (!this.IsOpen)
			{
				throw new InvalidOperationException("Repository must be open before a transaction can be committed.");
			}
			if (this.transaction == null)
			{
				throw new InvalidOperationException("Repository must have an open transaction in order to commit.");
			}
			this.transaction.Commit();
			this.transaction = null;
		}
		public void Rollback()
		{
			if (!this.isSessionCreator)
			{
				throw new Exception("A gateway that is sharing the session of another gateway cannot roll back a transaction on the shared session.");
			}
			if (!this.IsOpen)
			{
				throw new InvalidOperationException("Repository must be open before a transaction can be rolled back.");
			}
			if (this.transaction != null)
			{
				this.transaction.Rollback();
				this.transaction = null;
			}
		}
		private static bool GetIsOpen(ISession session)
		{
			if (session == null || !session.IsOpen)
			{
				return false;
			}
			// Session is open, connection could be either open or closed.
			// If connection is closed, signal that session is closed.
			if (!session.IsConnected)
			{
				return false;
			}
			return true;
		}
		public void Dispose(bool isDisposing)
		{
			if(isDisposing)
			{
				this.Close();
				if (this.transaction !=null)
				{
					this.transaction.Dispose();
					this.transaction = null;
				}
				if (this.session != null)
				{
					this.session.Dispose();
					this.session = null;
				}
				this.interceptor = null;
				if (Thread.GetData(mysessions) == this)
					Thread.SetData(mysessions, null);
			}
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		~Repository()      
		{
			Dispose(false);
		}
	}
}
