using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
            getEvent();

    }

    //button click events 
    protected void btnMakeEvent_Click(object sender, EventArgs e)
    {
        String eventName = txtEventName.Text;

        // seat list
        List<ListItem> seatsAvailable = new List<ListItem>();

        int first = Int32.Parse(txtFirstSeat.Text);
        int last = Int32.Parse(txtLastSeat.Text);

        for (int i = first; i <= last; i++)
            seatsAvailable.Add(new ListItem(i.ToString()));

        Session.Add("eventName", eventName);
        Session.Add("seatsAvailable", seatsAvailable);

        getEvent();

    }

    protected void btnPurchase_Click(object sender, EventArgs e)
    {

        List<ListItem> seatsAvailable = getSeatsAvailable();
        seatsAvailable.Remove(ddlSeat.SelectedItem);

        Hashtable seatsPurchased = getSeatsPurchased();
        double totalTicketsPrice = getTotalTicketsPrice();

        String purchase = ddlSeat.SelectedItem.Text + "\t " + txtAge.Text + "\t ";

        if (Int32.Parse(txtAge.Text) > 12)
        {

            purchase = purchase + "$10.00";
            totalTicketsPrice = totalTicketsPrice + 10;

        }
        else
        {

            purchase = purchase + "$5.00";
            totalTicketsPrice = totalTicketsPrice + 5;

        }

        seatsPurchased.Add(txtName.Text, purchase);

        Session.Add("seatsAvailable", seatsAvailable);
        Session.Add("seatsPurchased", seatsPurchased);
        Session.Add("totalTicketsPrice", totalTicketsPrice);

        getEvent();

    }

    protected void btnEventSummary_Click(object sender, EventArgs e)
    {
        Response.Redirect("Summary.aspx");

    }


    public void getEvent()
    {

        List<ListItem> seatsAvailable = getSeatsAvailable();

        ddlSeat.Items.Clear();
        foreach (ListItem listItem in seatsAvailable)
            ddlSeat.Items.Add(listItem);

        lblTicketsAvailable.Text = seatsAvailable.Count.ToString();

    }

    public List<ListItem> getSeatsAvailable()
    {

        List<ListItem> seatsAvailable;

        if (Session["seatsAvailable"] == null)
            seatsAvailable = new List<ListItem>();
        else
            seatsAvailable = (List<ListItem>)Session["seatsAvailable"];

        return seatsAvailable;

    }

    public Hashtable getSeatsPurchased()
    {

        Hashtable seatsPurchased;

        if (Session["seatsPurchased"] == null)
            seatsPurchased = new Hashtable();
        else
            seatsPurchased = (Hashtable)Session["seatsPurchased"];

        return seatsPurchased;

    }

    public double getTotalTicketsPrice()
    {

        double totalTicketsPrice;

        if (Session["totalTicketsPrice"] == null)
            totalTicketsPrice = 0;
        else
            totalTicketsPrice = (double)Session["totalTicketsPrice"];

        return totalTicketsPrice;

    }

}