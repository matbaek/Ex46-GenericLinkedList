using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public enum Gender { Male, Female };
    public class ClubMember : IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            ClubMember clubMemberObj = (ClubMember)obj;
            return this.FirstName.CompareTo(clubMemberObj.FirstName);
            //return string.Compare(this.FirstName, clubMemberObj.FirstName);
        }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} ({Gender}, {Age} years)";
        }

        public class SortClubMembersAfterLastName : IComparer<ClubMember>
        {
            public int Compare(ClubMember first, ClubMember second)
            {
                return string.Compare(first.LastName, second.LastName);
            }
        }

        public class SortClubMembersAfterGenderAndLastName : IComparer<ClubMember>
        {
            public int Compare(ClubMember first, ClubMember second)
            {
                if(first.Gender == second.Gender)
                {
                    return string.Compare(first.LastName, second.LastName);
                }
                else
                {
                    return first.Gender.CompareTo(second.Gender);
                }
            }
        }

    }

}
