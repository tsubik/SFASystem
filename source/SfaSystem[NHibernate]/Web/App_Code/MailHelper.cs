using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Collections;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using System.Text;

/// <summary>
/// Klasa zapewnia statyczne metody wspomagające proces przygotowania e-maili do wysłania.
/// </summary>
public class MailHelper
{

    /// <summary>
    /// Mail potwierdzający dokonanie zamówienia
    /// </summary>
    /// <param name="a_strMailAddress"></param>
    /// <param name="a_gActivationCode"></param>
    /// <param name="a_ctlOwner"></param>
    public static void SendApprovedOrderEmail(string emailAddress, Order order)
    {
        MailDefinition mailDefinition = new MailDefinition();
        mailDefinition.BodyFileName = "~/MailTemplates/ZamowienieWRealizacji.html";
        mailDefinition.IsBodyHtml = true;
        mailDefinition.Subject = "Nazwa firmy - Zamówienie w realizacji";
        IDictionary replacements = new Hashtable();

        //Dodawanie znaczników, które zostaną podmienione w szablonie maila na właściwe wartości
        replacements.Add("<%OrderDate%>", order.OrderDate.ToString("dd-MM-yyyy"));
        Address address = order.CustomerFacility.Address;
        String strAddress = "ul. " + address.Street +
            address.HouseNr + "/" + address.ApartmentNr + ", " +
            address.ZipCode + " " + address.City.Name + " " + address.Country.Name;
        replacements.Add("<%Address%>", strAddress);
        replacements.Add("<%Total%>", order.Total.ToString("0.00 zł"));

        MailMessage msg = mailDefinition.CreateMailMessage(emailAddress, replacements, new Panel());
        MailAddress mailFrom = new MailAddress(msg.From.Address, "Nazwa firmy");
        msg.From = mailFrom;

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(msg);
        
    }

    /// <summary>
    /// Mail potwierdzający wysyłke zamówienia
    /// </summary>
    /// <param name="a_strMailAddress"></param>
    /// <param name="a_gActivationCode"></param>
    /// <param name="a_ctlOwner"></param>
    public static void SendShippedOrderEmail(string emailAddress, Order order)
    {
        MailDefinition mailDefinition = new MailDefinition();
        mailDefinition.BodyFileName = "~/MailTemplates/ZamowienieWyslane.html";
        mailDefinition.IsBodyHtml = true;
        mailDefinition.Subject = "Nazwa firmy - Zamówienie wysłano";
        IDictionary replacements = new Hashtable();

        //Dodawanie znaczników, które zostaną podmienione w szablonie maila na właściwe wartości
        replacements.Add("<%OrderDate%>", order.OrderDate.ToString("dd-MM-yyyy"));
        Address address = order.CustomerFacility.Address;
        String strAddress = "ul. " + address.Street +
            address.HouseNr + "/" + address.ApartmentNr + ", " +
            address.ZipCode + " " + address.City.Name + " " + address.Country.Name;
        replacements.Add("<%Address%>", strAddress);
        replacements.Add("<%Total%>", order.Total.ToString("0.00 zł"));

        MailMessage msg = mailDefinition.CreateMailMessage(emailAddress, replacements, new Panel());
        MailAddress mailFrom = new MailAddress(msg.From.Address, "Nazwa firmy");
        msg.From = mailFrom;

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(msg);

    }
}
