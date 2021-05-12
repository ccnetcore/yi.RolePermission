using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.Yi.Model
{
    public class info_user
    {
        public info_user()
        {
            this.Info_Roles = new HashSet<info_role>();
            this.Info_Actions = new HashSet<info_action>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        public int is_delete { get; set; }

        public virtual ICollection<info_role> Info_Roles { get; set; }

        public virtual ICollection<info_action> Info_Actions { get; set; }
    }
}
