using CrimeRadius.Model;
using CrimesByRadius.Controllers;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CrimesByRadius.Tests.Controllers;

[TestClass]
[TestSubject(typeof(CrimesByRadiusController))]
public class CrimesByRadiusControllerTest
{

    [TestMethod]
    public void SerializeObjectToJson()
    {
        // Arrange
        var crimeReports = new[]
        {
            new CrimeData()
            {
                category = "anti-social-behaviour",
                location_type = "Force",
                location = new Location
                {
                    latitude = "51.449021",
                    street = new Street { id = 542387, name = "On or near Parking Area" },
                    longitude = "-2.500426"
                },
                context = "",
                outcome_status = new OutcomeStatus
                {
                    category = "",
                    date = ""
                },
                persistent_id = "",
                id = 89509657,
                location_subtype = "",
                month = "2021-01"
            }
        };

        // Act
        string json = JsonConvert.SerializeObject(crimeReports);

        // Assert
        Assert.AreEqual("[{\"category\":\"anti-social-behaviour\",\"location_type\":\"Force\",\"location\":{\"latitude\":\"51.449021\",\"street\":{\"id\":542387,\"name\":\"On or near Parking Area\"},\"longitude\":\"-2.500426\"},\"context\":\"\",\"outcome_status\":{\"category\":\"\",\"date\":\"\"},\"persistent_id\":\"\",\"id\":89509657,\"location_subtype\":\"\",\"month\":\"2021-01\"}]", json);
    }

    [TestMethod]
    public void DeserializeToObject()
    {
        // Arrange
        string jsonString = "[{\"category\":\"anti-social-behaviour\",\"location_type\":\"Force\",\"location\":{\"latitude\":\"51.449021\",\"street\":{\"id\":542387,\"name\":\"On or near Parking Area\"},\"longitude\":\"-2.500426\"},\"context\":\"\",\"outcome_status\":null,\"persistent_id\":\"\",\"id\":89509657,\"location_subtype\":\"\",\"month\":\"2021-01\"}]";

        // Act
        var crimeReports = JsonConvert.DeserializeObject<CrimeData[]>(jsonString);

        // Assert
        Assert.IsNotNull(crimeReports);
        Assert.AreEqual(1, crimeReports.Length);
        Assert.AreEqual("anti-social-behaviour", crimeReports[0].category);
        Assert.AreEqual("Force", crimeReports[0].location_type);
        Assert.AreEqual("51.449021", crimeReports[0].location.latitude);
        Assert.AreEqual(542387, crimeReports[0].location.street.id);
        Assert.AreEqual("On or near Parking Area", crimeReports[0].location.street.name);
        Assert.AreEqual("-2.500426", crimeReports[0].location.longitude);
        Assert.AreEqual("", crimeReports[0].context);
        Assert.AreEqual("", crimeReports[0].persistent_id);
        Assert.AreEqual(89509657, crimeReports[0].id);
        Assert.AreEqual("", crimeReports[0].location_subtype);
        Assert.AreEqual("2021-01", crimeReports[0].month);
    }
}