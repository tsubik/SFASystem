using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.Services;

public partial class Administration_Sales_InvoicePrint : System.Web.UI.Page
{
    protected int i = 0;
    private Invoice invoice;

    public Invoice Invoice
    {
        get { return invoice; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            invoice = BasicService<Invoice, Guid>.GetByID(this.InvoiceID);
            if (invoice != null)
            {



                DataBind();
            }
        }
    }

    public float CenaNetto(decimal brutto, int tax)
    {
        float nettoPrice = (float)brutto / (1 + (tax / 100.0f));
        return nettoPrice;
    }
    public float KwotaVAT(decimal brutto, float netto, int quantity)
    {
        return ((float)brutto - netto) * quantity;
    }
    private float sumaVAT;
    public float SumaVAT()
    {
        return sumaVAT;
    }
    private float sumaNetto;
    public float SumaNetto()
    {
        return sumaNetto;
    }
    private float sumaBrutto;
    public float SumaBrutto()
    {
        return sumaBrutto;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Guid InvoiceID
    {
        get
        {
            return CommonHelper.QueryStringGUID("InvoiceID");
        }
    }

    public string TworzAdres(CustomerFacility facility)
    {
        if (facility != null)
        {
            return "ul. "+ facility.Address.Street + " " + facility.Address.HouseNr + "/" + facility.Address.ApartmentNr + ", " +
                facility.Address.ZipCode + " " + facility.Address.City.Name + ", " + facility.Address.Country.Name;
        }
        else
            return string.Empty;
    }

    public string KwotaSlownie(string doub)
    {
        string kwota = null;
        string db = null;
        string post = "tysięcy";
        if (doub.Length < 9)
        {
            for (int i = 0; i < 9 - doub.Length; i++)
                db += "0";
        }
        db += doub;

        if (db.Substring(0, 1) == "1")
            kwota += " sto";
        else if (db.Substring(0, 1) == "2")
            kwota += " dwieście";
        else if (db.Substring(0, 1) == "3")
            kwota += " trzysta";
        else if (db.Substring(0, 1) == "4")
            kwota += " czterysta";
        else if (db.Substring(0, 1) == "5")
            kwota += " pięćset";
        else if (db.Substring(0, 1) == "6")
            kwota += " sześćset";
        else if (db.Substring(0, 1) == "7")
            kwota += " siedemset";
        else if (db.Substring(0, 1) == "8")
            kwota += " osiemset";
        else if (db.Substring(0, 1) == "9")
            kwota += " dziewięćset";


        if (db.Substring(1, 1) == "2")
            kwota += " dwadzieścia";
        else if (db.Substring(1, 1) == "3")
            kwota += " trzydzieści";
        else if (db.Substring(1, 1) == "4")
            kwota += " czterdeści";
        else if (db.Substring(1, 1) == " 5")
            kwota += " pięćdziesiąt";
        else if (db.Substring(1, 1) == "6")
            kwota += " sześćdziesiąt";
        else if (db.Substring(1, 1) == "7")
            kwota += " siedemdziesiat";
        else if (db.Substring(1, 1) == "8")
            kwota += " osiemdziesiąt";
        else if (db.Substring(1, 1) == "9")
            kwota += " dziewietset";


        if (db.Substring(1, 2) == "10")
            kwota += " dziesięć";
        else if (db.Substring(1, 2) == "11")
            kwota += " jedenaśie";
        else if (db.Substring(1, 2) == "12")
            kwota += " dwanaście";
        else if (db.Substring(1, 2) == "13")
            kwota += " trzynaście";
        else if (db.Substring(1, 2) == "14")
            kwota += " czternaście";
        else if (db.Substring(1, 2) == "15")
            kwota += " piętnaście";
        else if (db.Substring(1, 2) == "16")
            kwota += " szesnaście";
        else if (db.Substring(1, 2) == "17")
            kwota += " siedemnaście";
        else if (db.Substring(1, 2) == "18")
            kwota += " osiemnaście";
        else if (db.Substring(1, 2) == "19")
            kwota += " dziewietnaście";

        else if (db.Substring(2, 1) == "1")
        {
            kwota += " jeden";
            if (kwota == " jeden")
                post = "tysiąc";
        }
        else if (db.Substring(2, 1) == "2")
        {
            kwota += " dwa";
            post = "tysięce";
        }
        else if (db.Substring(2, 1) == "3")
        {
            kwota += " trzy";
            post = "tysięce";
        }
        else if (db.Substring(2, 1) == "4")
        {
            kwota += " cztery";
            post = "tysięce";
        }
        else if (db.Substring(2, 1) == "5")
            kwota += " pięć";
        else if (db.Substring(2, 1) == "6")
            kwota += " sześć";
        else if (db.Substring(2, 1) == "7")
            kwota += " siedem";
        else if (db.Substring(2, 1) == "8")
            kwota += " osiem";
        else if (db.Substring(2, 1) == "9")
            kwota += " dziewięć";
        if (doub.Length > 6)
            kwota += " " + post;

        if (db.Substring(3, 1) == "1")
            kwota += " sto";
        else if (db.Substring(3, 1) == "2")
            kwota += " dwieście";
        else if (db.Substring(3, 1) == "3")
            kwota += " trzysta";
        else if (db.Substring(3, 1) == "4")
            kwota += " czterysta";
        else if (db.Substring(3, 1) == "5")
            kwota += " pięćset";
        else if (db.Substring(3, 1) == "6")
            kwota += " sześćset";
        else if (db.Substring(3, 1) == "7")
            kwota += " siedemset";
        else if (db.Substring(3, 1) == "8")
            kwota += " osiemset";
        else if (db.Substring(3, 1) == "9")
            kwota += " dziewięćset";


        if (db.Substring(4, 1) == "2")
            kwota += " dwadzieścia";
        else if (db.Substring(4, 1) == "3")
            kwota += " trzydzieści";
        else if (db.Substring(4, 1) == "4")
            kwota += " czterdeści";
        else if (db.Substring(4, 1) == "5")
            kwota += " pięćdziesiąt";
        else if (db.Substring(4, 1) == "6")
            kwota += " sześćdziesiąt";
        else if (db.Substring(4, 1) == "7")
            kwota += " siedemdziesiat";
        else if (db.Substring(4, 1) == "8")
            kwota += " osiemdziesiąt";
        else if (db.Substring(4, 1) == "9")
            kwota += " dziewietset";

        if (db.Substring(4, 2) == "10")
            kwota += " dziesięć";
        else if (db.Substring(4, 2) == "11")
            kwota += " jedenaśie";
        else if (db.Substring(4, 2) == "12")
            kwota += " dwanaście";
        else if (db.Substring(4, 2) == "13")
            kwota += " trzynaście";
        else if (db.Substring(4, 2) == "14")
            kwota += " czternaście";
        else if (db.Substring(4, 2) == "15")
            kwota += " piętnaście";
        else if (db.Substring(4, 2) == "16")
            kwota += " szesnaście";
        else if (db.Substring(4, 2) == "17")
            kwota += " siedemnaście";
        else if (db.Substring(4, 2) == "18")
            kwota += " osiemnaście";
        else if (db.Substring(4, 2) == "19")
            kwota += " dziewietnaście";
        else if (db.Substring(5, 1) == "1")
            kwota += " jeden";
        else if (db.Substring(5, 1) == "2")
            kwota += " dwa";
        else if (db.Substring(5, 1) == "3")
            kwota += " trzy";
        else if (db.Substring(5, 1) == "4")
            kwota += " cztery";
        else if (db.Substring(5, 1) == "5")
            kwota += " pięć";
        else if (db.Substring(5, 1) == "6")
            kwota += " sześć";
        else if (db.Substring(5, 1) == "7")
            kwota += " siedem";
        else if (db.Substring(5, 1) == "8")
            kwota += " osiem";
        else if (db.Substring(5, 1) == "9")
            kwota += " dziewięć";
        if (kwota == null)
            kwota += " zero";
        kwota += " zł " + doub.Substring(doub.Length - 2) + "/100"; ;
        return kwota;
    }

}
