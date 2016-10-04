using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Summary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            getEvent();
    }
    protected void btnSellMoreTickets_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    public void getEvent()
    {

        lblEventName.Text = getEventName();
        Hashtable ticketSummary = getSeatsPurchased();
        List<ListItem> seatsAvailable = getSeatsAvailable();

        ddlName.Items.Clear();
        ddlName.Items.Add(new ListItem("Choose Person to Remove"));

        foreach (String key in ticketSummary.Keys)
            ddlName.Items.Add(new ListItem(key));

        txtSummary.Text = "Name" + '\t' + '\t' + " Seat" + '\t' + " Age" + '\t' + " Price" + '\n'
                        + "---------------" + '\t' + "-----" + '\t' + "----" + '\t' + "--------" + '\n';

		List<string> keysList = new List<string>();
		keysList.AddRange(ticketSummary.Keys.Cast<string>());

	    if (btnName.Checked)
			keysList.Sort();

	    if (btnSeat.Checked)
	    {
			SortedDictionary<int, string> dict = new SortedDictionary<int, string>();
		    foreach (string key in keysList)
		    {
			    string value = ticketSummary[key].ToString();
			    char currentChar = value[0];
			    int seatSubstringLength = 0;
			    while (Char.IsDigit(currentChar))
			    {
				    seatSubstringLength++;
				    currentChar = value[seatSubstringLength];
			    }
			    dict[int.Parse(value.Substring(0,seatSubstringLength))] = key;
		    }
			keysList.Clear();
		    keysList.AddRange(dict.Select(kvp => kvp.Value));
	    }


		foreach (String key in keysList)
            txtSummary.Text +=  key + " \t" + ticketSummary[key] + "\n";

        txtSummary.Text = txtSummary.Text + "---------------" + '\t' + "-----" + '\t' + "----" + '\t' + "--------" + "\n"
                        + "Tickets Sold: " + ticketSummary.Count + "\n"
                        + "Tickets Available: " + seatsAvailable.Count + "\n"
                        + "Total Ticket Prices: $" + Math.Round(getTotalTicketsPrice(), 2) + "\n"
                        + "Average Ticket Prices: $" + (ticketSummary.Count > 0 ? Math.Round((getTotalTicketsPrice() / ticketSummary.Count), 2) : 0) + "\n"
                        + "Available Seats: ";

        foreach (ListItem listItem in seatsAvailable)
            txtSummary.Text = txtSummary.Text + ", " + listItem.Text;

    }

    public String getEventName()
    {

        if (Session["eventName"] == null)
            return "No Event is Scheduled";

        String eventName = (String)Session["eventName"];

        return eventName;

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

    public List<ListItem> getSeatsAvailable()
    {

        List<ListItem> seatsAvailable;

        if (Session["seatsAvailable"] == null)
            seatsAvailable = new List<ListItem>();
        else
            seatsAvailable = (List<ListItem>)Session["seatsAvailable"];

        return seatsAvailable;

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

    protected void btnRemove_Click(object sender, EventArgs e)
    {
		string nameToRemove = ddlName.SelectedValue;

	    if (nameToRemove == "Choose Person to Remove")
		    return;
	  	    	
		((Hashtable)Session["seatsPurchased"]).Remove(nameToRemove);		
		ddlName.Items.RemoveAt(ddlName.SelectedIndex);
        ddlName.Items.Remove(txtSummary.ToString());

		getEvent();
    }

	//private void RemovePurchasedSeat(string )
	protected void btnOrderPurchased_CheckedChanged(object sender, EventArgs e)
	{
		getEvent();
	}
	protected void btnName_CheckedChanged(object sender, EventArgs e)
	{
		getEvent();
	}
	protected void btnSeat_CheckedChanged(object sender, EventArgs e)
	{
		getEvent();
	}
}