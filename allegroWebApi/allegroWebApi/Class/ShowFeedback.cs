using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using allegroWebApi.pl.allegro.webapi;

namespace allegroWebApi.Class
{
    class ShowFeedback
    {
        AllegroWebApiService service;
        private int feedbackCount;
        private FeedbackList[] feedBackList;
        public ShowFeedback(string sessionHandle, long userId)
        {
           service = new AllegroWebApiService();
           feedBackList = service.doGetFeedback(sessionHandle, 0, Convert.ToInt32(userId), 0, "ALL", out feedbackCount);
        }  
        public int ReturnFeedbackCount()
        {
            return feedbackCount;
        }
        public FeedbackList[] ReturnFeedbackList()
        {
            return feedBackList;
        }
    }
}
