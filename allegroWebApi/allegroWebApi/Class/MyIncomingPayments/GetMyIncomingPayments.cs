using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using allegroWebApi.pl.allegro.webapi;

namespace allegroWebApi.Class.MyIncomingPayments
{
    class GetMyIncomingPayments
    {
        private AllegroWebApiService service { get; set; }
        private UserIncomingPaymentStruct[] myIncomingPaymentStruct { get; set; }
        
        public GetMyIncomingPayments(string sessionHandle)
        {
            service = new AllegroWebApiService();
            myIncomingPaymentStruct = service.doGetMyIncomingPayments(sessionHandle ,0 ,0 ,0 ,0 ,0 ,0);
        }
        public UserIncomingPaymentStruct[] ReturnMyIncomingPayementStruct()
        {
            return myIncomingPaymentStruct;
        } 
    }
}
