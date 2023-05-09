using System;
using System.IO;
using FAXCOMEXLib;

namespace SendFaxApp.Model
{
    public class FaxSender
    {
        private static FaxServer faxServer;
        private FaxDocument faxDoc;
        
        public FaxSender(string bstrServerName)
        {
            try
            {
                faxServer = new FaxServer();
                faxServer.Connect(Environment.MachineName);
                RegisterFaxServerEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RegisterFaxServerEvents()
        {
            faxServer.OnOutgoingJobAdded += 
                new IFaxServerNotify2_OnOutgoingJobAddedEventHandler(faxServer_OnOutgoingJobAdded);
            faxServer.OnOutgoingJobChanged += 
                new IFaxServerNotify2_OnOutgoingJobChangedEventHandler(faxServer_OnOutgoingJobChanged);
            faxServer.OnOutgoingJobRemoved += 
                new IFaxServerNotify2_OnOutgoingJobRemovedEventHandler(faxServer_OnOutgoingJobRemoved);

            var eventsToListen = 
                FAX_SERVER_EVENTS_TYPE_ENUM.fsetFXSSVC_ENDED | FAX_SERVER_EVENTS_TYPE_ENUM.fsetOUT_QUEUE |
                FAX_SERVER_EVENTS_TYPE_ENUM.fsetOUT_ARCHIVE | FAX_SERVER_EVENTS_TYPE_ENUM.fsetQUEUE_STATE |
                FAX_SERVER_EVENTS_TYPE_ENUM.fsetACTIVITY | FAX_SERVER_EVENTS_TYPE_ENUM.fsetDEVICE_STATUS;

            faxServer.ListenToServerEvents(eventsToListen);
        }

        #region Event Listeners
        private static void faxServer_OnOutgoingJobAdded(FaxServer pFaxServer, string bstrJobId)
        {
            Console.WriteLine("OnOutgoingJobAdded event fired. A fax is added to the outgoing queue.");
        }

        private static void faxServer_OnOutgoingJobChanged(FaxServer pFaxServer, string bstrJobId, FaxJobStatus pJobStatus)
        {
            Console.WriteLine("OnOutgoingJobChanged event fired. A fax is changed to the outgoing queue.");
            pFaxServer.Folders.OutgoingQueue.Refresh();
            PrintFaxStatus(pJobStatus);
        }

        private static void faxServer_OnOutgoingJobRemoved(FaxServer pFaxServer, string bstrJobId)
        {
            Console.WriteLine("OnOutgoingJobRemoved event fired. Fax job is removed to outbound queue.");
        }
        #endregion

        private static void PrintFaxStatus(FaxJobStatus faxJobStatus)
        {
            if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesDIALING)
            {
                Console.WriteLine("Dialing...");
            }

            if (faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesTRANSMITTING)
            {
                Console.WriteLine("Sending Fax...");
            }

            if (faxJobStatus.Status == FAX_JOB_STATUS_ENUM.fjsCOMPLETED 
                && faxJobStatus.ExtendedStatusCode == FAX_JOB_EXTENDED_STATUS_ENUM.fjesCALL_COMPLETED)
            {
                Console.WriteLine("Fax is sent successfully.");
            }
        }

        public void SendFax(FaxSenderInfo faxSenderInfo, FaxDocInfo faxDocInfo, FaxRecipientsInfo faxRecipientsInfo)
        {
            try
            {
                FaxDocumentSetup(faxSenderInfo, faxDocInfo, faxRecipientsInfo);
                object submitReturnValue = faxDoc.Submit(faxServer.ServerName);
                faxDoc = null;                
            }
            catch (Exception comException)
            {
                Console.WriteLine("Error connecting to fax server. Error Message: " + comException.Message);
                Console.WriteLine("StackTrace: " + comException.StackTrace);
            }
        }

        private void FaxDocumentSetup(FaxSenderInfo faxSenderInfo, FaxDocInfo faxDocInfo, FaxRecipientsInfo faxRecipientsInfo)
        {
            faxDoc = new FaxDocument();
            faxDoc.Priority = FAX_PRIORITY_TYPE_ENUM.fptHIGH;
            faxDoc.ReceiptType = FAX_RECEIPT_TYPE_ENUM.frtNONE;
            faxDoc.AttachFaxToReceipt = true;

            faxDoc.Sender.Name = faxSenderInfo.Name;
            faxDoc.Sender.Company = faxSenderInfo.CompanyName;
            faxDoc.Body = faxDocInfo.Body;
            faxDoc.Subject = faxSenderInfo.Subject;
            faxDoc.DocumentName = faxDocInfo.DocumentName;
            faxDoc.Recipients.Add(faxRecipientsInfo.bstrFaxNumber, faxRecipientsInfo.bstrRecipientName);
        }

        public void SendFaxMultiFiles(FaxSenderInfo faxSenderInfo, FaxDocInfo faxDocInfo, FaxRecipientsInfo faxRecipientsInfo)
        {
            try
            {
                FaxDocumentSetupMultiFiles(faxSenderInfo, faxDocInfo, faxRecipientsInfo);
                object objFaxOutgouingJobIds;
                object submitReturnValue = faxDoc.Submit2(faxServer.ServerName, out objFaxOutgouingJobIds);
                faxDoc = null;
            }
            catch (Exception comException)
            {
                Console.WriteLine("Error connecting to fax server. Error Message: " + comException.Message);
                Console.WriteLine("StackTrace: " + comException.StackTrace);
            }
        }

        private void FaxDocumentSetupMultiFiles(FaxSenderInfo faxSenderInfo, FaxDocInfo faxDocInfo, FaxRecipientsInfo faxRecipientsInfo)
        {
            faxDoc = new FaxDocument();
            faxDoc.Priority = FAX_PRIORITY_TYPE_ENUM.fptHIGH;
            faxDoc.ReceiptType = FAX_RECEIPT_TYPE_ENUM.frtNONE;
            faxDoc.AttachFaxToReceipt = true;

            faxDoc.Sender.Name = faxSenderInfo.Name;
            faxDoc.Sender.Company = faxSenderInfo.CompanyName;
            faxDoc.Bodies = faxDocInfo.Bodies.ToArray();
            faxDoc.Subject = faxSenderInfo.Subject;
            faxDoc.DocumentName = faxDocInfo.DocumentName;
            faxDoc.Recipients.Add(faxRecipientsInfo.bstrFaxNumber, faxRecipientsInfo.bstrRecipientName);
        }

    }
}

