using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Windows.Forms;
using SFASystem.Pocket.App.Forms;

namespace SFASystem.Pocket.App.Code
{
    public class ApplicationManager : Singleton<ApplicationManager>
    {
        private AccountForm accountForm;
        private CustomerForm customerForm;
        private CustomerDetailsForm customerDetailsForm;
        private FacilityDetailsForm facilityDetailsForm;
        private TaskForm taskForm;
        private LogonForm logonForm;
        private MainForm mainForm;
        private ProductsForm productsForm;
        private ProductGroupForm productGroupForm;
        private OrderForm orderForm;

        public AccountForm AccountForm
        {
            get
            {
                if (accountForm == null)
                    accountForm = new AccountForm();
                return accountForm;
            }
        }
        public TaskForm TaskForm
        {
            get
            {
                if (taskForm == null)
                    taskForm = new TaskForm();
                return taskForm;
            }
        }
        private TaskDetails taskDetailsForm;
        public TaskDetails TaskDetailsForm
        {
            get
            {
                if (taskDetailsForm == null)
                    taskDetailsForm = new TaskDetails();
                return taskDetailsForm;
            }
        }

        public CustomerForm CustomerForm
        {
            get
            {
                if (customerForm == null)
                    customerForm = new CustomerForm();
                return customerForm;
            }
        }
        public CustomerDetailsForm CustomerDetailsForm
        {
            get
            {
                if (customerDetailsForm == null)
                    customerDetailsForm = new CustomerDetailsForm();
                return customerDetailsForm;
            }
        }
        public FacilityDetailsForm FacilityDetailsForm
        {
            get
            {
                if (facilityDetailsForm == null)
                    facilityDetailsForm = new FacilityDetailsForm();
                return facilityDetailsForm;
            }
        }
        public OrderForm OrderForm
        {
            get
            {
                if (orderForm == null)
                    orderForm = new OrderForm();
                return orderForm;
            }
        }

        public LogonForm LogonForm
        {
            get
            {
                if (logonForm == null)
                    logonForm = new LogonForm();
                return logonForm;
            }
        }
        public MainForm MainForm
        {
            get
            {
                if (mainForm == null)
                    mainForm = new MainForm();
                return mainForm;
            }
        }
        public ProductsForm ProductsForm
        {
            get
            {
                if (productsForm == null)
                    productsForm = new ProductsForm();
                return productsForm;
            }
        }

        public ProductGroupForm ProductGroupForm
        {
            get
            {
                if (productGroupForm == null)
                    productGroupForm = new ProductGroupForm();
                return productGroupForm;
            }
        }

        public void ShowForm(Form oldForm, Form newform)
        {
            newform.Show();
            oldForm.Hide();
            
            //form.Show();
        }
        
        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; }
        }

        private bool isWebServiceAuth = false;
        public bool IsWebServiceAuth
        {
            get { return isWebServiceAuth; }
            set { isWebServiceAuth = value; }
        }

    }
}
