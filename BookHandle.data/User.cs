using System.ComponentModel.DataAnnotations.Schema;

namespace BookHandle.data
{

    /*
     
    150 table 
    ENT1xx
        ENT1xx_01
        ENT1xx_02
        ENT1xx_03 - 1 hour 

    ENT1xx_1y
        
    ENT1y
     
     */



    public class User : Identifiable<int>
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime dob { get; set; }
        public string middlename { get; set; }
        public List<Privilege> Privileges { get; set; }
    }

    // Index Table 1..n [One to many] 
    // [ UserID  | PrivilegeID]
    // [1        | 1          ]
    // [1        | 2          ]
    // 
    public class UserPrivilege : Identifiable<int>
    {
        public int userid { get; set; }
        public User user { get; set; }
        public int privilegeid { get; set; }
        public Privilege privilege { get; set; }
    }

    public class Privilege : Identifiable<int>
    {
        //navigation property 
        // PK/FK

        public int Userid { get; set; }
        public User user { get; set; }

        public DateTime expiry { get; set; }
        public string name { get; set; }
        public int level { get; set; }
    }



    public abstract class Identifiable<T>
    {
        public T id { get; set; }
    }
}