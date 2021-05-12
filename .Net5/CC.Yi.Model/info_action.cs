using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.Yi.Model
{
    public class info_action
    {
        public info_action()
        { 
             this.info_Roles=new HashSet<info_role>();
            this.Info_Users = new HashSet<info_user>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string action_name { get; set; }

        public int is_delete { get; set; }

        public string router { get; set; }

        public string icon { get; set; }

        public virtual ICollection<info_role> info_Roles { get; set; }

        public virtual ICollection<info_user> Info_Users { get; set; }
    }
}
