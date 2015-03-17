using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSW.TimeProAPI.Extension;
using SSW.TimeProAPI.Models;
using TimeProAPI.Models;

namespace SSW.TimeProAPI
{
    public class InvoicesAPIHelper
    {
        private readonly string _apiKey;
        private readonly string _timeProUrlID;

        public InvoicesAPIHelper(string timeProUrlID, string apiKey)
        {
            _timeProUrlID = timeProUrlID;
            _apiKey = apiKey;
        }

        private string BaseRequestUri
        {
            get { return "https://" + _timeProUrlID + ".sswtimepro.com/api/Invoices/"; }
        }


        public async Task<InvoiceModel> CreateInvoiceAsync(ClientInvoiceModel invoice, List<ClientInvoiceProductModel> clientInvoiceProducts, List<PartialTimesheetsModel> timesheets)
        {
            var invoiceDto = new InvoiceModel { ClientInvoice = invoice, ClientInvoiceProducts = clientInvoiceProducts, Timesheets = timesheets };

            using (var client = new HttpClient())
            {
                string invoiceDTOJson = JsonConvert.SerializeObject(invoiceDto);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);
                var content = new StringContent(invoiceDTOJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InvoiceModel>(responseString);
            } 
        }
        
        public async Task<InvoiceModel> CreateInvoiceAsync(ClientInvoiceModel invoice, List<PartialTimesheetsModel> timesheets)
        {   
            var clientInvoiceProducts = new List<ClientInvoiceProductModel>();
            var result = await CreateInvoiceAsync(invoice, clientInvoiceProducts, timesheets);
            return result;
        }

        public async Task<InvoiceModel> CreateInvoiceAsync(ClientInvoiceModel invoice, List<ClientInvoiceProductModel> clientInvoiceProducts)
        {
            var timesheets = new List<PartialTimesheetsModel>();
            var result = await CreateInvoiceAsync(invoice, clientInvoiceProducts, timesheets);
            return result;
        }

        public async Task<InvoiceModel> EditInvoiceAsync(ClientInvoiceEditModel invoice, List<ClientInvoiceProductEditModel> clientInvoiceProducts, List<PartialTimesheetsEditModel> timesheets)
        {
            var invoiceDto = new InvoiceEditModel { ClientInvoice = invoice, ClientInvoiceProducts = clientInvoiceProducts, Timesheets = timesheets };

            using (var client = new HttpClient())
            {
                string invoiceDTOJson = JsonConvert.SerializeObject(invoiceDto);

                client.DefaultRequestHeaders.Authorization = HelperMethods.CreateAuthorizationHeader(_apiKey);
                var content = new StringContent(invoiceDTOJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(BaseRequestUri, content);

                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InvoiceModel>(responseString);
            }
        }



        public async Task<InvoiceModel> EditInvoiceAsync(ClientInvoiceEditModel invoice, List<PartialTimesheetsEditModel> timesheets)
        {
            var clientInvoiceProducts = new List<ClientInvoiceProductEditModel>();
            var result = await EditInvoiceAsync(invoice, clientInvoiceProducts, timesheets);
            return result;
        }

        public async Task<InvoiceModel> EditInvoiceAsync(ClientInvoiceEditModel invoice, List<ClientInvoiceProductEditModel> clientInvoiceProducts)
        {
            var timesheets = new List<PartialTimesheetsEditModel>();
            var result = await EditInvoiceAsync(invoice, clientInvoiceProducts, timesheets);
            return result;
        }


    }
}