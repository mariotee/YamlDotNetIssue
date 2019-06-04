using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using YamlDotNetTests.Interfaces;

namespace YamlDotNetTests.Tests
{    
    public class TestClass
    {
        private string test_data_path = Path.Combine(
            Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location),
            "Tests", "TestData");

        [TestCase("Test1.yaml", TestName = "first")]
        public void getListOfPets(string filename)
        {
            //ARRANGE
            string yaml = File.ReadAllText(Path.Combine(test_data_path, filename));
            //ACT
            var res = YamlUtil.fromYaml<SampleClass>(yaml);
            //ASSERT
            Assert.AreEqual(4,res.pets.Count());
        }

        [TestCase("Test1.yaml", TestName = "second")]
        public void getPetsStream(string filename)
        {
            //ARRANGE
            string yaml = File.ReadAllText(Path.Combine(test_data_path, filename));
            //ACT
            var res = YamlUtil.fromYamlStream<SampleClass>(yaml);
            //ASSERT
            Assert.AreEqual(4, res.pets.Count());
        }
    }

    internal class SampleClass
    {
        public IEnumerable<IAnimal> pets;
    }
}
