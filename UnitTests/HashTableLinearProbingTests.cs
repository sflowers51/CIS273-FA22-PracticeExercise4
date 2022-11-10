using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeExercise4;

namespace UnitTests
{
    [TestClass]
    public class HashTableLinearProbingTests
    {
        [TestMethod]
        public void Add_Get_String_Int()
        {

            var ht = new HashTableLinearProbing<string, int>();

            ht.Add("XBX", 1);
            ht.Add("XCD", 2);
            ht.Add("EP", 3);
            ht.Add("ON", 4);
            ht.Add("PKA", 5);
            ht.Add("PM", 6);

            Assert.AreEqual(ht.Count, 6);
            Assert.AreEqual(ht.Get("PM"), 6);
            Assert.AreEqual(ht.Get("ON"), 4);

        }

        [TestMethod]
        public void Remove_String_Int()
        {
            var ht = new HashTableLinearProbing<string, int>();

            ht.Add("XBX", 1);
            ht.Add("XCD", 2);
            ht.Add("EP", 3);
            ht.Add("ON", 4);
            ht.Add("PKA", 5);

            Assert.AreEqual(ht.Count, 5);
            Assert.AreEqual(ht.Get("XBX"), 1);

            ht.Remove("XBX");

            Assert.AreEqual(ht.Count, 4);
            Assert.IsFalse(ht.ContainsKey("XBX"));

            // remove a key that's not in the hashtable
            ht.Remove("XBX");
            Assert.AreEqual(ht.Count, 4);

            ht.Remove("XCD");
            ht.Remove("EP");
            ht.Remove("ON");
            ht.Remove("PKA");

            Assert.AreEqual(ht.Count, 0);
        }

        [TestMethod]
        public void ContainsKey_String_String()
        {
            var ht = new HashTableLinearProbing<string, string>();

            ht.Add("XBX", "bible");
            ht.Add("XCD", "hipster");
            ht.Add("EP", "toga");
            ht.Add("ON", "outcast");
            ht.Add("PKA", "redneck");

            Assert.AreEqual(ht.Get("XBX"), "bible");
            Assert.IsTrue(ht.ContainsKey("XBX"));
            Assert.IsTrue(ht.ContainsKey("PKA"));
            Assert.IsTrue(ht.ContainsKey("XCD"));
            Assert.IsFalse(ht.ContainsKey("PM"));

            ht.Remove("XBX");

            Assert.IsFalse(ht.ContainsKey("XBX"));
        }


        [TestMethod]
        public void ContainsValue_String_String()
        {
            var ht = new HashTableLinearProbing<string, string>();

            ht.Add("XBX", "bible");
            ht.Add("XCD", "hipster");
            ht.Add("EP", "toga");
            ht.Add("ON", "outcast");
            ht.Add("PKA", "redneck");

            Assert.AreEqual(ht.Get("ON"), "outcast");
            Assert.IsTrue(ht.ContainsValue("outcast"));
            Assert.IsTrue(ht.ContainsValue("toga"));
            Assert.IsTrue(ht.ContainsValue("redneck"));

            Assert.IsFalse(ht.ContainsValue("foo"));

            ht.Remove("XBX");

            Assert.IsFalse(ht.ContainsKey("bible"));
        }

        [TestMethod]
        public void AddDuplicate_String_String()
        {
            var ht = new HashTableLinearProbing<string, string>();

            ht.Add("XBX", "bible");
            ht.Add("XCD", "hipster");
            ht.Add("EP", "toga");
            ht.Add("ON", "outcast");
            ht.Add("PKA", "redneck");
            ht.Add("PKA", "tractor");
            ht.Add("PKA", "yeeeeet");

            Assert.AreEqual(ht.Count, 5);
            Assert.AreEqual(ht.Get("PKA"), "yeeeeet");
        }


        [TestMethod]
        public void AddDuplicate_String_Int()
        {
            var ht = new HashTableLinearProbing<string, int>();

            ht.Add("XBX", 1);
            ht.Add("XCD", 2);
            ht.Add("EP", 3);
            ht.Add("ON", 4);
            ht.Add("PKA", 5);
            ht.Add("PM", 6);
            ht.Add("PM", 7);
            ht.Add("PM", 8);
            ht.Add("PM", 9);
            ht.Add("PM", 10);

            Assert.AreEqual(ht.Count, 6);
            Assert.AreEqual(ht.Get("PM"), 10);
        }

        [TestMethod]
        public void Resize_String_Int()
        {
            var ht = new HashTableLinearProbing<string, int>();

            ht.Add("a", 12);
            ht.Add("b", 12);
            ht.Add("c", 12);
            ht.Add("d", 12);
            ht.Add("e", 12);
            ht.Add("f", 12);
            ht.Add("g", 12);
            ht.Add("h", 12);
            ht.Add("i", 12);
            ht.Add("j", 12);
            ht.Add("k", 12);
            ht.Add("l", 12);
            ht.Add("m", 12);
            ht.Add("n", 12);
            ht.Add("o", 12);
            ht.Add("p", 12);
            ht.Add("q", 12);
            ht.Add("r", 12);
            ht.Add("s", 12);
            ht.Add("t", 12);
            ht.Add("u", 12);
            ht.Add("v", 12);
            ht.Add("w", 12);

            Assert.AreEqual(ht.Count, 23);
            Assert.AreEqual(ht.GetValues().Count, 23);

        }

    }
}
