using CarRentalCore.Exceptions;
using CarRentalCore.Interfaces;
using CarRentalCore.Requests;
using CarRentalCore.Services;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RentalCarCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentalAPI.Test
{
    [TestFixture]
    public class VehicleServiceTest
    {
        Mock<IBaseDataAcces<Vehicle>> baseDataAccesMock = null;

        [SetUp]
        public void Initialize()
        {
            baseDataAccesMock = new Mock<IBaseDataAcces<Vehicle>>();
        }

        [Test]
        public async Task WhenDatesWrong_ShouldThrowException()
        {
            DateTime dateFromRent = DateTime.Today;
            DateTime dateToRent = DateTime.Today.AddDays(-1);            
            VehicleService service = new VehicleService(baseDataAccesMock.Object);
            AvailableVehiclesRequest request=new AvailableVehiclesRequest { DateFrom= dateFromRent, DateTo= dateToRent, VehicleTypeId=2};
          
            Assert.That(() => service.GetAvailables(request), Throws.Exception);

        }

    }
}
