﻿using FakeXrmEasy;
using SummitEmea.Plugins;
using System;
using System.Linq;
using TypedEntities;
using Xunit;

namespace SummitEmea.UnitTests
{
    public class PhoneCallHistoryTests
    {
        [Fact]
        public void Should_create_phone_call_history_on_create_of_a_phonecall_with_its_details()
        {
            //var ctx = new XrmFakedContext();
            //Assert.True(false);


            //Arrange ==> 
            //Act  
            //Assert ==>

            var ctx = new XrmFakedContext();
            var service = ctx.GetOrganizationService();


            var contact = new Contact() { Id = Guid.NewGuid() };

            var phoneCall = new PhoneCall()
            {
                Id = Guid.NewGuid(),
                RegardingObjectId = contact.ToEntityReference(),
                PhoneNumber = "+34666666666"
            };

            ctx.ExecutePluginWithTarget<PhoneCallCreatePlugin>(phoneCall);

            var historyRecords = ctx.CreateQuery<ultra_phonecallhistory>().ToList();
            Assert.Single(historyRecords);

            var historyRecord = historyRecords.First();
            Assert.Equal(phoneCall.PhoneNumber, historyRecord.ultra_phonenumber);
            Assert.Equal(phoneCall.RegardingObjectId.Id, historyRecord.ultra_contactid.Id);
            Assert.Equal(historyRecord.Id, phoneCall.ultra_phonecallhistoryid.Id);

        }

        [Fact]
        public void Shouldnt_create_a_duplicate_phone_call_history_record()
        {
            var ctx = new XrmFakedContext();

            var contact = new Contact() { Id = Guid.NewGuid() };

            var phoneCall = new PhoneCall()
            {
                Id = Guid.NewGuid(),
                RegardingObjectId = contact.ToEntityReference(),
                PhoneNumber = "+34666666666"
            };

            var existingPhoneCallHistory = new ultra_phonecallhistory()
            {
                Id = Guid.NewGuid(),
                ultra_contactid = contact.ToEntityReference(),
                ultra_phonenumber = phoneCall.PhoneNumber
            };
            ctx.Initialize(existingPhoneCallHistory);

            ctx.ExecutePluginWithTarget<PhoneCallCreatePlugin>(phoneCall);

            var historyRecords = ctx.CreateQuery<ultra_phonecallhistory>().ToList();
            Assert.Single(historyRecords);
        }


    }
}
