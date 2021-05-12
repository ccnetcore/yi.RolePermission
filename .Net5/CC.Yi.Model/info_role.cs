using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.Yi.Model
{
    public  class info_role
    {
        public info_role()
        {
            this.Info_Users = new HashSet<info_user>();
            this.Info_Actions = new HashSet<info_action>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string role_name { get; set; }

        public int is_delete { get; set; }

        public virtual ICollection<info_action> Info_Actions { get; set; }

        public virtual ICollection<info_user> Info_Users { get; set; }
    }
}
