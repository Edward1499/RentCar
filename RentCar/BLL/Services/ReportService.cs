using BLL.Connected_Services.ReportExecutionService;
using BLL.DTOs.Reports;
using BLL.Services.Interfaces;
using ReportExecutionService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        public async Task<string> Generate(ReportDTO request, string mainDirectory)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            binding.MaxReceivedMessageSize = 10485760; //10MB limit

            const string SSRSReportExecutionUrl = "http://edward/ReportServer/ReportExecution2005.asmx?wsdl";

            var rsExec = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(SSRSReportExecutionUrl));

            if (rsExec.ClientCredentials != null)
            {
                rsExec.ClientCredentials.Windows.AllowedImpersonationLevel =
                    System.Security.Principal.TokenImpersonationLevel.Impersonation;
                rsExec.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
            }

            try
            {
                rsExec.Endpoint.EndpointBehaviors.Add(new ReportingServicesEndpointBehavior());
                await rsExec.LoadReportAsync(null, "/testreport", null);
                ParameterValue[] parameters = new ParameterValue[2];
                parameters[0] = new ParameterValue();
                parameters[0].Name = "StartDate";
                parameters[0].Value = request.StartDate.ToString("yyyy-MM-dd");
                parameters[1] = new ParameterValue();
                parameters[1].Name = "EndDate";
                parameters[1].Value = request.EndDate.ToString("yyyy-MM-dd"); ;
                await rsExec.SetExecutionParametersAsync(null, null, Parameters: parameters, ParameterLanguage: "");

                string deviceInfo = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

                string path = Path.Combine(mainDirectory, "wwwroot\\Files", "tempreport.pdf");
                var response = await rsExec.RenderAsync(new RenderRequest(null, null, "PDF", deviceInfo));
                File.WriteAllBytes(path, response.Result);

                return $"https://localhost:7110/Files/tempreport.pdf";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
