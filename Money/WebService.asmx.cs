using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
[WebMethod]
public string CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
{
WebClient web = new WebClient();
string url = string.Format("http://www.google.com/ig/calculator?hl=en&q={2}{0}%3D%3F{1}", fromCurrency.ToUpper(), toCurrency.ToUpper(), amount);
string response = web.DownloadString(url);
Regex regex = new Regex(@":(?<rhs>.+?),");
string[] arrDigits = regex.Split(response);
string rate = arrDigits[3];
return rate;
}
}