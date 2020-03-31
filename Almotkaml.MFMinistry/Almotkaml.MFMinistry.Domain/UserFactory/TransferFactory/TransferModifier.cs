﻿using System;

namespace Almotkaml.MFMinistry.Domain.TransferFactory
{
    public class TransferModifier
    {
        internal TransferModifier(Transfer transfer)
        {
            Transfer = transfer;
        }

        private Transfer Transfer { get; }

        public TransferModifier JobTypeTransfer(JobTypeTransfer jobTypeTransfer)
        {
            Transfer.JobTypeTransfer = jobTypeTransfer;
            return this;
        }

        public TransferModifier DateFrom(DateTime dateFrom)
        {
            Transfer.DateFrom = dateFrom;
            return this;
        }

        public TransferModifier DateTo(DateTime dateTo)
        {
            Transfer.DateTo = dateTo;
            return this;
        }

        public TransferModifier SideName(string sideName)
        {
            Transfer.SideName = sideName;
            return this;
        }

        public Transfer Confirm()
        {
            Transfer.Activities.Add(Activity.New(InMemory<Notify>.LoggedInUserId, nameof(Notify.OnTransfer_Edit)));
            return Transfer;
        }
    }
}
