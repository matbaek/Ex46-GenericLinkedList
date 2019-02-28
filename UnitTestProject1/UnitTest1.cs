using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        ClubMember p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13,
                   p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25;

        [TestInitialize]
        public void Initialize()
        {
            p1 = new ClubMember { Id = 1, FirstName = "Farrand", LastName = "Semkins", Gender = Gender.Female, Age = 77 };
            p2 = new ClubMember { Id = 2, FirstName = "Trev", LastName = "Quail", Gender = Gender.Male, Age = 84 };
            p3 = new ClubMember { Id = 3, FirstName = "Dani", LastName = "Ballister", Gender = Gender.Female, Age = 76 };
            p4 = new ClubMember { Id = 4, FirstName = "Hyacinthie", LastName = "Mish", Gender = Gender.Female, Age = 70 };
            p5 = new ClubMember { Id = 5, FirstName = "Jarib", LastName = "Boustred", Gender = Gender.Male, Age = 32 };
            p6 = new ClubMember { Id = 6, FirstName = "Erl", LastName = "Meeson", Gender = Gender.Male, Age = 62 };
            p7 = new ClubMember { Id = 7, FirstName = "Aile", LastName = "Highman", Gender = Gender.Female, Age = 79 };
            p8 = new ClubMember { Id = 8, FirstName = "Rheta", LastName = "Battelle", Gender = Gender.Female, Age = 42 };
            p9 = new ClubMember { Id = 9, FirstName = "Olimpia", LastName = "Foulsham", Gender = Gender.Female, Age = 60 };
            p10 = new ClubMember { Id = 10, FirstName = "Dagny", LastName = "Ilchenko", Gender = Gender.Male, Age = 34 };
            p11 = new ClubMember { Id = 11, FirstName = "Davis", LastName = "Gilbride", Gender = Gender.Male, Age = 46 };
            p12 = new ClubMember { Id = 12, FirstName = "Kamillah", LastName = "Bahls", Gender = Gender.Female, Age = 24 };
            p13 = new ClubMember { Id = 13, FirstName = "Flore", LastName = "Ansley", Gender = Gender.Female, Age = 89 };
            p14 = new ClubMember { Id = 14, FirstName = "Glad", LastName = "Clowser", Gender = Gender.Female, Age = 48 };
            p15 = new ClubMember { Id = 15, FirstName = "Christian", LastName = "Congram", Gender = Gender.Female, Age = 33 };
            p16 = new ClubMember { Id = 16, FirstName = "Tore", LastName = "Saggs", Gender = Gender.Male, Age = 28 };
            p17 = new ClubMember { Id = 17, FirstName = "Vevay", LastName = "Klezmski", Gender = Gender.Female, Age = 43 };
            p18 = new ClubMember { Id = 18, FirstName = "Bren", LastName = "Merrikin", Gender = Gender.Female, Age = 46 };
            p19 = new ClubMember { Id = 19, FirstName = "Benoit", LastName = "Filler", Gender = Gender.Male, Age = 16 };
            p20 = new ClubMember { Id = 20, FirstName = "Lucien", LastName = "Bottrell", Gender = Gender.Male, Age = 41 };
            p21 = new ClubMember { Id = 21, FirstName = "Emmy", LastName = "Pechell", Gender = Gender.Male, Age = 61 };
            p22 = new ClubMember { Id = 22, FirstName = "Merle", LastName = "Bennet", Gender = Gender.Female, Age = 42 };
            p23 = new ClubMember { Id = 23, FirstName = "Solomon", LastName = "Sarrell", Gender = Gender.Male, Age = 61 };
            p24 = new ClubMember { Id = 24, FirstName = "Shurlock", LastName = "Shreenan", Gender = Gender.Male, Age = 84 };
            p25 = new ClubMember { Id = 25, FirstName = "Chadd", LastName = "Hanney", Gender = Gender.Male, Age = 80 };
        }

        [TestMethod]
        public void TestGenericIEnumerable()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p3);  // p3
            list.Insert(p22); // p3, p22
            list.Insert(p9);  // p9, p3, p22
            list.Insert(p1);  // p1, p9, p3, p22
            list.Append(p24); // p1, p9, p3, p22, p24
            list.Append(p5);  // p1, p9, p3, p22, p24, p5
            list.Append(p16); // p1, p9, p3, p22, p24, p5, p16

            int i = 0;
            // foreach gives members in expected order
            foreach (ClubMember li in list)
            {
                Assert.AreEqual(list.ItemAt(i++), li);
            }
            // and we got to the end
            Assert.AreEqual(list.Count, i);

            int j = 0;
            var e = list.GetEnumerator();
            // and the enumerator does the same
            while (e.MoveNext())
            {
                Assert.AreEqual(list.ItemAt(j++), e.Current);
            }

            // reset starts all over
            e.Reset();
            j = 0;
            while (e.MoveNext())
            {
                Assert.AreEqual(list.ItemAt(j++), e.Current);
            }
        }


        [TestMethod]
        public void TestGenericEmptyLinkedListHasZeroMembers()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEmptyGenericLinkedListHasNoFirst()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();

            Assert.AreEqual(null, list.First);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEmptyGenericLinkedListHasNoLast()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();

            Assert.AreEqual(null, list.Last);
        }

        [TestMethod]
        public void TestGenericAppend()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Append(p1);  // p1
            list.Append(p7);  // p1, p7
            list.Append(p13); // p1, p7, p13

            Assert.AreEqual(p1, list.First);
            Assert.AreEqual(p13, list.Last);
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(p1, list.ItemAt(0));
            Assert.AreEqual(p7, list.ItemAt(1));
            Assert.AreEqual(p13, list.ItemAt(2));
        }

        [TestMethod]
        public void TestGenericInsert()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p5);  // p5
            list.Insert(p21); // p21, p5
            list.Insert(p9);  // p9, p21, p5
            list.Insert(p24); // p24, p9, p21, p5

            Assert.AreEqual(p24, list.First);
            Assert.AreEqual(p5, list.Last);
            Assert.AreEqual(4, list.Count);

            Assert.AreEqual(p24, list.ItemAt(0));
            Assert.AreEqual(p9, list.ItemAt(1));
            Assert.AreEqual(p21, list.ItemAt(2));
            Assert.AreEqual(p5, list.ItemAt(3));
        }

        [TestMethod]
        public void TestGenericMixedInserts()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p3);  // p3
            list.Append(p22); // p3, p22
            list.Insert(p9);  // p9, p3, p22
            list.Insert(p1);  // p1, p9, p3, p22
            list.Append(p24); // p1, p9, p3, p22, p24
            list.Insert(p5);  // p5, p1, p9, p3, p22, p24
            list.Append(p16); // p5, p1, p9, p3, p22, p24, p16

            Assert.AreEqual(p5, list.First);
            Assert.AreEqual(p16, list.Last);
            Assert.AreEqual(7, list.Count);

            Assert.AreEqual(p5, list.ItemAt(0));
            Assert.AreEqual(p1, list.ItemAt(1));
            Assert.AreEqual(p9, list.ItemAt(2));
            Assert.AreEqual(p3, list.ItemAt(3));
            Assert.AreEqual(p22, list.ItemAt(4));
            Assert.AreEqual(p24, list.ItemAt(5));
            Assert.AreEqual(p16, list.ItemAt(6));
        }

        [TestMethod]
        public void TestGenericDelete()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p5);  // p5
            list.Insert(p21); // p21, p5
            list.Insert(p9);  // p9, p21, p5
            list.Insert(p24); // p24, p9, p21, p5
            list.Delete(2);   // p24, p9, p5

            Assert.AreEqual(p24, list.First);
            Assert.AreEqual(p5, list.Last);
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(p24, list.ItemAt(0));
            Assert.AreEqual(p9, list.ItemAt(1));
            Assert.AreEqual(p5, list.ItemAt(2));
        }

        [TestMethod]
        public void TestgenericDeleteFirst()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p5);  // p5
            list.Insert(p21); // p21, p5
            list.Insert(p9);  // p9, p21, p5
            list.Insert(p24); // p24, p9, p21, p5
            list.Delete(0);   // p9, p21, p5

            Assert.AreEqual(p9, list.ItemAt(0));
            Assert.AreEqual(p21, list.ItemAt(1));
            Assert.AreEqual(p5, list.ItemAt(2));
        }

        [TestMethod]
        public void TestgenericDeleteLast()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p5);  // p5
            list.Insert(p21); // p21, p5
            list.Insert(p9);  // p9, p21, p5
            list.Insert(p24); // p24, p9, p21, p5
            list.Delete(3);   // p24, p9, p21

            Assert.AreEqual(p24, list.ItemAt(0));
            Assert.AreEqual(p9, list.ItemAt(1));
            Assert.AreEqual(p21, list.ItemAt(2));
        }

        [TestMethod]
        public void TestGenericMixedInsertsAndDeletes()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p3);  // p3
            list.Append(p22); // p3, p22
            list.Insert(p9);  // p9, p3, p22
            list.Delete(0);   // p3, p22
            list.Insert(p1);  // p1, p3, p22
            list.Append(p24); // p1, p3, p22, p24
            list.Insert(p5);  // p5, p1, p3, p22, p24
            list.Delete(4);   // p5, p1, p3, p22
            list.Append(p16); // p5, p1, p3, p22, p16
            list.Delete(2);   // p5, p1, p22, p16

            Assert.AreEqual(p5, list.First);
            Assert.AreEqual(p16, list.Last);
            Assert.AreEqual(4, list.Count);

            Assert.AreEqual(p5, list.ItemAt(0));
            Assert.AreEqual(p1, list.ItemAt(1));
            Assert.AreEqual(p22, list.ItemAt(2));
            Assert.AreEqual(p16, list.ItemAt(3));
            Assert.AreEqual("5: Jarib Boustred (Male, 32 years)\n1: Farrand Semkins (Female, 77 years)\n22: Merle Bennet (Female, 42 years)\n16: Tore Saggs (Male, 28 years)\n", list.ToString());
        }

        [TestMethod]
        public void TestGenericListOnInt()
        {
            // ** int list test *********
            MyLinkedList<int> listInt = new MyLinkedList<int>();

            // Insert ints and test
            listInt.Append(105); // 105
            listInt.Append(45);  // 105, 45
            listInt.Append(11);  // 105, 45, 11
            listInt.Append(3);   // 105, 45, 11, 3

            Assert.AreEqual(105, listInt.First);
            Assert.AreEqual(3, listInt.Last);
            Assert.AreEqual(4, listInt.Count);

            Assert.AreEqual(105, listInt.ItemAt(0));
            Assert.AreEqual(45, listInt.ItemAt(1));
            Assert.AreEqual(11, listInt.ItemAt(2));
            Assert.AreEqual(3, listInt.ItemAt(3));
        }

        [TestMethod]
        public void TestGenericListOnString()
        {
            // ** string list test **********
            MyLinkedList<string> listString = new MyLinkedList<string>();

            // Insert strings and test
            listString.Append("Hello World!");         // "Hello World!"
            listString.Append("This is a ");           // "Hello World!", "This is a "
            listString.Append("test of ");             // "Hello World!", "This is a ", "test of "
            listString.Append("MyLinkedList<string>"); // "Hello World!", "This is a ", "test of ", "MyLinkedList<string>"

            Assert.AreEqual("Hello World!", listString.First);
            Assert.AreEqual("MyLinkedList<string>", listString.Last);
            Assert.AreEqual(4, listString.Count);

            Assert.AreEqual("Hello World!", listString.ItemAt(0));
            Assert.AreEqual("This is a ", listString.ItemAt(1));
            Assert.AreEqual("test of ", listString.ItemAt(2));
            Assert.AreEqual("MyLinkedList<string>", listString.ItemAt(3));
        }

        [TestMethod]
        public void TestGenericListOnDecimal()
        {
            // ** decimal list test ***********
            MyLinkedList<decimal> listDecimal = new MyLinkedList<decimal>();

            // Insert decimals and test
            listDecimal.Append(3.1415m); // 3.1415m
            listDecimal.Append(1.4142m); // 3.1415m, 1.4142m
            listDecimal.Append(2.7182m); // 3.1415m, 1.4142m, 2.7182m
            listDecimal.Append(1.6180m); // 3.1415m, 1.4142m, 2.7182m, 1.6180m

            Assert.AreEqual(3.1415m, listDecimal.First);
            Assert.AreEqual(1.6180m, listDecimal.Last);
            Assert.AreEqual(4, listDecimal.Count);

            Assert.AreEqual(3.1415m, listDecimal.ItemAt(0)); // Pi
            Assert.AreEqual(1.4142m, listDecimal.ItemAt(1)); // squareroot of 2
            Assert.AreEqual(2.7182m, listDecimal.ItemAt(2)); // Euler
            Assert.AreEqual(1.6180m, listDecimal.ItemAt(3)); // Golden ratio
        }

        [TestMethod]
        public void TestClubMemberCompareTo()
        {
            ClubMember cm1, cm2, cm3, cm4;
            cm1 = new ClubMember();
            cm2 = new ClubMember();
            cm3 = new ClubMember();
            cm4 = new ClubMember();
            cm1.FirstName = "A";
            cm2.FirstName = "B";
            cm3.FirstName = "C";
            cm4.FirstName = "C";

            Assert.IsTrue(cm1.CompareTo(cm2) < 0);
            Assert.IsTrue(cm3.CompareTo(cm2) > 0);
            Assert.IsTrue(cm2.CompareTo(cm3) < 0);
            Assert.AreEqual(cm3.CompareTo(cm4), 0);
        }


        [TestMethod]
        public void TestBubbleSortClubMember()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p4);  // p4
            list.Insert(p9);  // p9, p4
            list.Insert(p5);  // p5, p9, p4
            list.Insert(p19); // p19, p5, p9, p4
            list.Insert(p23); // p23, p19, p5, p9, p4
            list.Insert(p2);  // p2, p23, p19, p5, p9, p4

            list.Sort(); // Sort on FirstName

            Assert.AreEqual(p19, list.ItemAt(0));
            Assert.AreEqual(p4, list.ItemAt(1));
            Assert.AreEqual(p5, list.ItemAt(2));
            Assert.AreEqual(p9, list.ItemAt(3));
            Assert.AreEqual(p23, list.ItemAt(4));
            Assert.AreEqual(p2, list.ItemAt(5));
        }

        [TestMethod]
        public void TestBubbleSortInt()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Insert(55);  // 55
            list.Insert(78);  // 78, 55
            list.Insert(23);  // 23, 78, 55
            list.Insert(88);  // 88, 23, 78, 55
            list.Insert(62);  // 62, 88, 23, 78, 55
            list.Insert(49);  // 49, 62, 88, 23, 78, 55

            list.Sort();

            Assert.AreEqual(23, list.ItemAt(0));
            Assert.AreEqual(49, list.ItemAt(1));
            Assert.AreEqual(55, list.ItemAt(2));
            Assert.AreEqual(62, list.ItemAt(3));
            Assert.AreEqual(78, list.ItemAt(4));
            Assert.AreEqual(88, list.ItemAt(5));
        }

        [TestMethod]
        public void TestSortClubMembersAfterLastName_Compare()
        {
            IComparer<ClubMember> ic = new ClubMember.SortClubMembersAfterLastName();

            Assert.IsTrue(ic.Compare(p4, p13) > 0);   // Mish - Ansley
            Assert.IsTrue(ic.Compare(p4, p24) < 0);   // Mish - Shreenan
            Assert.IsTrue(ic.Compare(p24, p13) > 0);  // Shreenan - Ansley
            Assert.IsTrue(ic.Compare(p24, p24) == 0); // Shreenan - Shreenan
        }


        public void TestSortClubMembersAfterLastName()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p2);  // LastName : Quail
            list.Insert(p4);  // LastName : Mish
            list.Insert(p23); // LastName : Sarrell
            list.Insert(p9);  // LastName : Foulsham
            list.Insert(p5);  // LastName : Boustred
            list.Insert(p19); // LastName : Filler


            list.Sort(new ClubMember.SortClubMembersAfterLastName()); // Sort on LastName

            Assert.AreEqual(p5, list.ItemAt(0));  // LastName : Boustred
            Assert.AreEqual(p19, list.ItemAt(1)); // LastName : Filler
            Assert.AreEqual(p9, list.ItemAt(2));  // LastName : Foulsham
            Assert.AreEqual(p4, list.ItemAt(3));  // LastName : Mish
            Assert.AreEqual(p2, list.ItemAt(4));  // LastName : Quail
            Assert.AreEqual(p23, list.ItemAt(5)); // LastName : Sarrell        
        }


        [TestMethod]
        public void TestSortClubMembersAfterGenderAndLastName()
        {
            MyLinkedList<ClubMember> list = new MyLinkedList<ClubMember>();
            list.Insert(p2);  // Gender : Male,   LastName : Quail
            list.Insert(p4);  // Gender : Female, LastName : Mish
            list.Insert(p23); // Gender : Male,   LastName : Sarrell
            list.Insert(p9);  // Gender : Female, LastName : Foulsham
            list.Insert(p5);  // Gender : Male,   LastName : Boustred
            list.Insert(p19); // Gender : Male,   LastName : Filler
            list.Insert(p13); // Gender : Female, LastName : Ansley

            list.Sort(new ClubMember.SortClubMembersAfterGenderAndLastName());

            Assert.AreEqual(p5, list.ItemAt(0));  // Gender : Male,   LastName : Boustred
            Assert.AreEqual(p19, list.ItemAt(1)); // Gender : Male,   LastName : Filler
            Assert.AreEqual(p2, list.ItemAt(2));  // Gender : Male,   LastName : Quail
            Assert.AreEqual(p23, list.ItemAt(3)); // Gender : Male,   LastName : Sarrell
            Assert.AreEqual(p13, list.ItemAt(4)); // Gender : Female, LastName : Ansley
            Assert.AreEqual(p9, list.ItemAt(5));  // Gender : Female, LastName : Foulsham
            Assert.AreEqual(p4, list.ItemAt(6));  // Gender : Female, LastName : Mish
        }
    }
}
