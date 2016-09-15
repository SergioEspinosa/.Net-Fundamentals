using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace CarRentalService.Trace
{
    public class TraceInspector : IDispatchMessageInspector
    {
        class TraceInfo : Exception
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Request { get; set; }
            public string Action { get; set; }
            public string Response { get; set; }
            public TraceInfo():base("TraceInfo")
            {

            }

            public override string ToString()
            {
                var newLine = Environment.NewLine;
              return  $"Action:{Action}{newLine}Request:{Request}{newLine}Response:{Response}{newLine}StartDate:{StartDate}{newLine}EndDate:{EndDate}";
            }
        }

        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (string.IsNullOrEmpty(request.ToString()))
            {
                return null;
            }
            
            return new TraceInfo
            {
                StartDate = DateTime.Now,
                Request = request.ToString(),
                Action = request.Headers.Action
            };
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var param = (TraceInfo)correlationState;
            if (reply != null)
            {
                param.Response = reply.IsFault
                    ? "Check the error log"
                    : reply.ToString();
            }

            param.EndDate = DateTime.Now;
                       
            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(param));
        }

        #endregion

    }
}
