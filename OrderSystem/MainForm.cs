using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrderSystem
{
    public partial class MainForm : Form
    {
        Controller controller;
        public MainForm(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            TextBoxDate.Text = DateTime.Now.ToShortDateString();
            TextBoxTotalPrice.Text = "0";
            TextBoxOrderAmount.Text = "1";
            TextBoxOrderNumber.Text = controller.GetOrderNbr().ToString();
        }

        //Clear fields

        private void ClearCustomerInformation()
        {
            TextBoxSsn.Clear();
            TextBoxFirstName.Clear();
            TextBoxLastName.Clear();
            TextBoxAdress.Clear();
            TextBoxEmail.Clear();
            TextBoxPhoneNumber.Clear();
            TextBoxCity.Clear();
            TextBoxPostcode.Clear();
        }

        private void ClearCustomerInUseInformation()
        {
            TextBoxUseSsn.Clear();
            TextBoxUseFirstName.Clear();
            TextBoxUseLastName.Clear();
            TextBoxUseEmail.Clear();
            TextBoxUseAdress.Clear();
            TextBoxUseCity.Clear();
            TextBoxUsePhoneNumber.Clear();
            TextBoxUsePostcode.Clear();
        }

        private void ClearProductInformation()
        {
            TextBoxProductNumber.Clear();
            TextBoxProductName.Clear();
            TextBoxStock.Clear();
            TextBoxPrice.Clear();
        }

        private void ClearOrderInformation()
        {
            TextBoxTotalPrice.Text = "0";
            TextBoxOrderNumber.Text = controller.GetOrderNbr().ToString();
            ListViewCart.Items.Clear();
        }

        //Customer Methods

        private void CreateCustomer()
        {
            String[] CustomerData = new String[8];

            if (TextBoxSsn.Text.Length != 10) ///SSN invalid lenght
            {
                MessageBox.Show("Ssn Requires ten digits");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxFirstName.Text, "^[0-9]+$")) //Firstname invalid characters
            {
                MessageBox.Show("Enter only alphabets in Customer firstname");
            }

            else if (String.IsNullOrEmpty(TextBoxFirstName.Text)) //Firstname empty 
            {
                MessageBox.Show("You forgot to fill in the Customer firstname");
            }

            else if (String.IsNullOrEmpty(TextBoxLastName.Text)) //Lastname empty
            {
                MessageBox.Show("You forgot to fill in the Customer lastname");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxLastName.Text, "^[0-9]+$")) //Lastname invalid characters
            {
                MessageBox.Show("Enter only alphabets in Customer lastname");
            }

            else if (String.IsNullOrWhiteSpace(TextBoxEmail.Text)) //Email empty
            {
                MessageBox.Show("You forgot to fill in the Customer Email box");
            }

            else if (String.IsNullOrEmpty(TextBoxAdress.Text)) //Adress empty
            {
                MessageBox.Show("You forgot to fill in the Customer Adress");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxPhoneNumber.Text, "^[a-zA-Z]+$")) //Phone invalid characters
            {
                MessageBox.Show("Enter only numbers in Customer phonenumbers");
            }

            else if (String.IsNullOrEmpty(TextBoxPhoneNumber.Text)) //Phone empty
            {
                MessageBox.Show("You forgot to fill in the Customer phonenumber");
            }

            else if (String.IsNullOrEmpty(TextBoxCity.Text)) //City empty
            {
                MessageBox.Show("You forgot to fill in the Customer City");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxCity.Text, "^[0-9]+$")) //City invalid characters
            {
                MessageBox.Show("Enter only alphabets in Customer City");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxPostcode.Text, "^[a-zA-Z]+$")) //Postcode invalid characters
            {
                MessageBox.Show("Enter only number in Customer postcode");
            }

            else if (String.IsNullOrEmpty(TextBoxPostcode.Text)) //Postcode empty
            {
                MessageBox.Show("You forgot to fill in the Customer postcode");
            }

            else
            {
                try
                {
                    CustomerData[0] = TextBoxSsn.Text;
                    CustomerData[1] = TextBoxFirstName.Text;
                    CustomerData[2] = TextBoxLastName.Text;
                    CustomerData[3] = TextBoxEmail.Text;
                    CustomerData[4] = TextBoxAdress.Text;
                    CustomerData[5] = TextBoxPhoneNumber.Text;
                    CustomerData[6] = TextBoxCity.Text;
                    CustomerData[7] = TextBoxPostcode.Text;

                    controller.CreateCustomer(CustomerData);
                    ClearCustomerInformation();
                    Search();
                    MessageBox.Show("You have now Created Customer" + " " + CustomerData[0], "HardWood System,");


                }
                catch (Exception Ex)
                {
                    string errorMessage = controller.HandleException(Ex);
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void DeleteCustomer()
        {
            if (String.IsNullOrEmpty(TextBoxSsn.Text))
            {

                MessageBox.Show("The customer does not exist");
            }
            else
            {
                try
                {
                    String Ssn = TextBoxSsn.Text;
                    controller.DeleteCustomer(Ssn);
                    ClearCustomerInformation();
                    Search();
                    MessageBox.Show("You have now Delteted Customer" + " " + Ssn, "HardWood System,");
                }
                catch (Exception Ex)
                {
                    string errorMessage = controller.HandleException(Ex);
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void UpdateCustomer()
        {
            String[] CustomerData = new String[8];

            CustomerData[0] = TextBoxSsn.Text;
            CustomerData[1] = TextBoxFirstName.Text;
            CustomerData[2] = TextBoxLastName.Text;
            CustomerData[3] = TextBoxEmail.Text;
            CustomerData[4] = TextBoxAdress.Text;
            CustomerData[5] = TextBoxPhoneNumber.Text;
            CustomerData[6] = TextBoxCity.Text;
            CustomerData[7] = TextBoxPostcode.Text;

            try
            {
                controller.UpdateCustomer(CustomerData);
                if (String.IsNullOrEmpty(TextBoxSsn.Text))
                {
                    MessageBox.Show("You have to choose a customer");
                }
                else
                {
                    MessageBox.Show("You have now Updated Customer" + " " + CustomerData[0], "HardWood System,");
                }
                ClearCustomerInformation();
                Search();


            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Product Methods

        private void CreateProduct()
        {
            string[] ProductData = new string[4];

            if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxProductNumber.Text, "^[a-zA-Z]+$")) //Productnumber invalid characters
            {
                MessageBox.Show("Enter only number in product number");
            }

            else if (String.IsNullOrEmpty(TextBoxProductNumber.Text)) //Product name empty
            {
                MessageBox.Show("You forgot to fill in the product number");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxProductName.Text, "^[0-9]+$")) //Product name invalid characters
            {
                MessageBox.Show("Enter only alphabets in product name");
            }

            else if (String.IsNullOrEmpty(TextBoxProductName.Text)) //Product name empty
            {
                MessageBox.Show("You forgot to fill in the product name");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxStock.Text, "^[a-zA-Z]+$")) //Product stock invalid characters
            {
                MessageBox.Show("Enter only number in product stock");
            }

            else if (String.IsNullOrEmpty(TextBoxStock.Text)) //Product stock empty
            {
                MessageBox.Show("You forgot to fill in the product number");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(TextBoxPrice.Text, "^[a-zA-Z]+$")) //Text price invalid characters
            {
                MessageBox.Show("Enter only number in product price");
            }

            else if (String.IsNullOrEmpty(TextBoxPrice.Text)) // Text price empty
            {
                MessageBox.Show("You forgot to fill in the product price");
            }
            else
            {
                ProductData[0] = TextBoxProductNumber.Text;
                ProductData[1] = TextBoxProductName.Text;
                ProductData[2] = TextBoxStock.Text;
                ProductData[3] = TextBoxPrice.Text;

                try
                {
                    controller.CreateProduct(ProductData);
                    ClearProductInformation();
                    Search();
                    MessageBox.Show("You have now Created Product" + " " + ProductData[0], "HardWood System,");
                }
                catch (Exception Ex)
                {
                    string errorMessage = controller.HandleException(Ex);
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteProduct()
        {
            try
            {
                if (String.IsNullOrEmpty(TextBoxProductNumber.Text))
                {

                    MessageBox.Show("The product does not exist");
                }
                else
                {
                    String ProductNbr = TextBoxProductNumber.Text;
                    controller.DeleteProduct(ProductNbr);
                    ClearProductInformation();
                    Search();
                    MessageBox.Show("You have now Deleteted Product" + " " + ProductNbr, "HardWood System,");
                }
            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateProduct()
        {
            String[] ProductData = new String[8];

            ProductData[0] = TextBoxProductNumber.Text;
            ProductData[1] = TextBoxProductName.Text;
            ProductData[2] = TextBoxStock.Text;
            ProductData[3] = TextBoxPrice.Text;

            try
            {
                controller.UpdateProduct(ProductData);
                if (String.IsNullOrEmpty(TextBoxProductNumber.Text))
                {
                    MessageBox.Show("You have to choose a product");
                }
                else
                {
                    MessageBox.Show("You have now Updated Product" + " " + ProductData[0], "HardWood System,");
                }
                ClearProductInformation();
                Search();

            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Order Methods

        private void CreateOrder()
        {
            string[] OrderData = new string[4];

            OrderData[0] = TextBoxOrderNumber.Text;
            OrderData[1] = TextBoxDate.Text;
            OrderData[2] = TextBoxTotalPrice.Text;
            OrderData[3] = TextBoxUseSsn.Text;

            try
            {
                controller.CreateOrder(OrderData);
                MessageBox.Show("You have now Created Order" + " " + OrderData[0], "HardWood System,");
            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (ListViewItem item in ListViewCart.Items)
            {
                string[] OrderrowData = new string[4];

                OrderrowData[0] = item.SubItems[0].Text;
                OrderrowData[1] = TextBoxOrderNumber.Text;
                OrderrowData[2] = item.SubItems[3].Text;
                OrderrowData[3] = item.SubItems[4].Text;

                controller.CreateOrderrow(OrderrowData);
            }
            ClearCustomerInUseInformation();
            ClearOrderInformation();
            TextBoxOrderNumber.Text = controller.GetOrderNbr().ToString();
            Search();
        }

        private void DeleteOrder()
        {

            string OrderNbr = TextBoxOrderNumber.Text;
            try
            {
                controller.DeleteOrder(OrderNbr);
                MessageBox.Show("You have now Deleted Order" + " " + OrderNbr, "HardWood System,");

            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearOrderInformation();
            ClearCustomerInUseInformation();
            Search();

        }

        //Functional Methods

        private void Search()
        {
            try
            {
                if (RadioButtonCustomer.Checked == true)
                {
                    ListViewCustomer.Items.Clear();

                    string CustomerSearch = TextBoxSearch.Text;
                    DataSet Ds = new DataSet();

                    controller.SearchCustomer(CustomerSearch, Ds);
                    foreach (DataRow Dr in Ds.Tables[0].Rows)
                    {
                        ListViewItem CustomerItem = new ListViewItem(Dr["cNbr"].ToString());
                        CustomerItem.SubItems.Add(Dr["cFirstName"].ToString());
                        CustomerItem.SubItems.Add(Dr["cLastName"].ToString());

                        ListViewCustomer.Items.Add(CustomerItem);
                    }

                }
                else if (RadioButtonProduct.Checked == true)
                {
                    ListViewProduct.Items.Clear();

                    String ProductSearch = TextBoxSearch.Text;
                    DataSet Ds = new DataSet();
                    controller.SearchProduct(ProductSearch, Ds);

                    foreach (DataRow Dr in Ds.Tables[0].Rows)
                    {
                        ListViewItem ProductItem = new ListViewItem(Dr["pNbr"].ToString());
                        ProductItem.SubItems.Add(Dr["pName"].ToString());
                        ProductItem.SubItems.Add(Dr["pPrice"].ToString());
                        ProductItem.SubItems.Add(Dr["pStock"].ToString());

                        ListViewProduct.Items.Add(ProductItem);
                    }
                }
                else if (RadioButtonOrder.Checked == true)
                {
                    ListViewOrder.Items.Clear();

                    String OrderSearch = TextBoxSearch.Text;
                    DataSet Ds = new DataSet();
                    controller.SearchOrder(OrderSearch, Ds);

                    foreach (DataRow Dr in Ds.Tables[0].Rows)
                    {
                        ListViewItem OrderItem = new ListViewItem(Dr["oNbr"].ToString());
                        OrderItem.SubItems.Add(Dr["cNbr"].ToString());
                        OrderItem.SubItems.Add(Dr["oDate"].ToString());

                        ListViewOrder.Items.Add(OrderItem);
                    }
                }
            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Insert()
        {
            try
            {
                if (RadioButtonCustomer.Checked == true)
                {
                    if (TabControlMain.SelectedTab == TabPageCreate) //INSERT CUSTOMER IN CUSTOMER HANDLING TAB
                    {
                        string CustomerSsn = ListViewCustomer.SelectedItems[0].SubItems[0].Text;

                        DataSet Ds = new DataSet();

                        controller.PopulateCustomer(CustomerSsn, Ds);

                        TextBoxSsn.Text = Ds.Tables[0].Rows[0]["cNbr"].ToString();
                        TextBoxFirstName.Text = Ds.Tables[0].Rows[0]["cFirstName"].ToString();
                        TextBoxLastName.Text = Ds.Tables[0].Rows[0]["cLastName"].ToString();
                        TextBoxEmail.Text = Ds.Tables[0].Rows[0]["cMail"].ToString();
                        TextBoxAdress.Text = Ds.Tables[0].Rows[0]["cAdress"].ToString();
                        TextBoxPhoneNumber.Text = Ds.Tables[0].Rows[0]["cPhoneNbr"].ToString();
                        TextBoxCity.Text = Ds.Tables[0].Rows[0]["cCity"].ToString();
                        TextBoxPostcode.Text = Ds.Tables[0].Rows[0]["cPostalCode"].ToString();

                        ClearProductInformation();
                    }
                    else if (TabControlMain.SelectedTab == TabPageCreateOrder) //INSERT CUSTOMER IN ORDER TAB
                    {

                        string CustomerSsn = ListViewCustomer.SelectedItems[0].SubItems[0].Text;

                        DataSet Ds = new DataSet();

                        controller.PopulateCustomer(CustomerSsn, Ds);

                        TextBoxUseSsn.Text = Ds.Tables[0].Rows[0]["cNbr"].ToString();
                        TextBoxUseFirstName.Text = Ds.Tables[0].Rows[0]["cFirstName"].ToString();
                        TextBoxUseLastName.Text = Ds.Tables[0].Rows[0]["cLastName"].ToString();
                        TextBoxUseEmail.Text = Ds.Tables[0].Rows[0]["cMail"].ToString();
                        TextBoxUseAdress.Text = Ds.Tables[0].Rows[0]["cAdress"].ToString();
                        TextBoxUsePhoneNumber.Text = Ds.Tables[0].Rows[0]["cPhoneNbr"].ToString();
                        TextBoxUseCity.Text = Ds.Tables[0].Rows[0]["cCity"].ToString();
                        TextBoxUsePostcode.Text = Ds.Tables[0].Rows[0]["cPostalCode"].ToString();
                    }
                }
                else if (RadioButtonProduct.Checked == true)
                {
                    if (TabControlMain.SelectedTab == TabPageCreate) //INSERT PRODUCT IN PRODUCT HANDLING TAB
                    {
                        string ProductNbr = ListViewProduct.SelectedItems[0].SubItems[0].Text;

                        DataSet Ds = new DataSet();

                        controller.PopulateProduct(ProductNbr, Ds);

                        TextBoxProductNumber.Text = Ds.Tables[0].Rows[0]["pNbr"].ToString();
                        TextBoxProductName.Text = Ds.Tables[0].Rows[0]["pName"].ToString();
                        TextBoxStock.Text = Ds.Tables[0].Rows[0]["pStock"].ToString();
                        TextBoxPrice.Text = Ds.Tables[0].Rows[0]["pPrice"].ToString();

                        ClearCustomerInformation();
                    }
                    else if (TabControlMain.SelectedTab == TabPageCreateOrder) //INSERT PRODUCT INTO ORDER CART
                    {

                        string ProductNbr = ListViewProduct.SelectedItems[0].SubItems[0].Text;

                        int ProductAmount = Convert.ToInt32(TextBoxOrderAmount.Text);
                        int ProductPrice = Convert.ToInt32(ListViewProduct.SelectedItems[0].SubItems[2].Text);
                        int ProductTotalPriceTemp = Convert.ToInt32(TextBoxTotalPrice.Text);
                        int ProductTotalPriceCart = (ProductPrice * ProductAmount) + ProductTotalPriceTemp;
                        int ProductTotalPrice = (ProductPrice * ProductAmount);

                        DataSet Ds = new DataSet();

                        controller.PopulateProduct(ProductNbr, Ds);

                        foreach (DataRow Dr in Ds.Tables[0].Rows)
                        {
                            ListViewItem ProductItem = new ListViewItem(Dr["pNbr"].ToString());
                            ProductItem.SubItems.Add(Dr["pName"].ToString());
                            ProductItem.SubItems.Add(Dr["pPrice"].ToString());
                            ProductItem.SubItems.Add(ProductAmount.ToString());
                            ProductItem.SubItems.Add(ProductTotalPrice.ToString());

                            ListViewCart.Items.Add(ProductItem);
                        }
                        TextBoxTotalPrice.Text = ProductTotalPriceCart.ToString();
                        TextBoxOrderAmount.Clear();
                        TextBoxOrderAmount.Text = "1";
                    }
                }
                else if (RadioButtonOrder.Checked == true) //POPULATE ORDER TAB
                {
                    try
                    {
                        TextBoxDate.Clear();
                        string OrderNbr = ListViewOrder.SelectedItems[0].SubItems[0].Text;

                        DataSet Ds = new DataSet();
                        controller.SearchOrder(OrderNbr, Ds);

                        TextBoxOrderNumber.Text = Ds.Tables[0].Rows[0]["oNbr"].ToString();
                        TextBoxDate.Text = Ds.Tables[0].Rows[0]["oDate"].ToString();

                        string CustomerNbr = Ds.Tables[0].Rows[0]["cNbr"].ToString();

                        Ds.Clear();
                        ListViewCart.Items.Clear();
                        controller.SearchCustomer(CustomerNbr, Ds);

                        TextBoxUseFirstName.Text = Ds.Tables[0].Rows[0]["cFirstName"].ToString();
                        TextBoxUseLastName.Text = Ds.Tables[0].Rows[0]["cLastName"].ToString();
                        TextBoxUseSsn.Text = Ds.Tables[0].Rows[0]["cNbr"].ToString();
                        TextBoxUseEmail.Text = Ds.Tables[0].Rows[0]["cMail"].ToString();
                        TextBoxUsePhoneNumber.Text = Ds.Tables[0].Rows[0]["cPhoneNbr"].ToString();
                        TextBoxUseAdress.Text = Ds.Tables[0].Rows[0]["cAdress"].ToString();
                        TextBoxUseCity.Text = Ds.Tables[0].Rows[0]["cCity"].ToString();
                        TextBoxUsePostcode.Text = Ds.Tables[0].Rows[0]["cPostalcode"].ToString();

                        Ds.Clear();

                        controller.SearchOrderrow(OrderNbr, Ds);
                        foreach (DataRow Dr in Ds.Tables[0].Rows)
                        {
                            ListViewItem ProductItem = new ListViewItem(Dr["pNbr"].ToString());
                            ProductItem.SubItems.Add(Dr["pName"].ToString());
                            ProductItem.SubItems.Add(Dr["pPrice"].ToString());
                            ProductItem.SubItems.Add(Dr["oAmount"].ToString());
                            ProductItem.SubItems.Add(Dr["oTotalPrice"].ToString());

                            ListViewCart.Items.Add(ProductItem);
                        }
                        Ds.Clear();
                    }
                    catch (Exception Ex)
                    {
                        string errorMessage = controller.HandleException(Ex);
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                string errorMessage = controller.HandleException(Ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteProductCart()
        {
            foreach (ListViewItem eachItem in ListViewCart.SelectedItems)
            {
                ListViewCart.Items.Remove(eachItem);
            }
        }
        //Buttons

        private void ButtonCreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomer();
        }

        private void ButtonDeleteCustomer_Click(object sender, EventArgs e)
        {

            DeleteCustomer();

        }

        private void ButtonUpdateCustomer_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void ButtonCreateProduct_Click(object sender, EventArgs e)
        {
            CreateProduct();
        }

        private void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void ButtonUpdateProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrder();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void ButtonDeleteProductCart_Click(object sender, EventArgs e)
        {
            DeleteProductCart();
        }

        private void ButtonDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }


        //RadioButtons

        private void RadioButtonCustomer_CheckedChanged(object sender, EventArgs e)
        {
            LabelOrderAmount.Visible = false;
            TextBoxOrderAmount.Visible = false;
            ListViewCustomer.Visible = true;
            ListViewProduct.Visible = false;
            ListViewOrder.Visible = false;
        }

        private void RadioButtonProduct_CheckedChanged(object sender, EventArgs e)
        {
            LabelOrderAmount.Visible = true;
            TextBoxOrderAmount.Visible = true;
            ListViewOrder.Visible = false;
            ListViewProduct.Visible = true;
            ListViewCustomer.Visible = false;
        }

        private void RadioButtonOrder_CheckedChanged_1(object sender, EventArgs e)
        {
            LabelOrderAmount.Visible = false;
            TextBoxOrderAmount.Visible = false;
            ListViewOrder.Visible = true;
            ListViewProduct.Visible = false;
            ListViewCustomer.Visible = false;
        }


    }
}
