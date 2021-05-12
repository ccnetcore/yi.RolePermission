<template>
  <v-card class="mx-auto" height="100%" width="100%">
    <!-- deep-purple -->

    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="title"> 权限管理系统 </v-list-item-title>
        <v-list-item-subtitle> 正式版 </v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>

    <v-list>
      <v-list-item v-for="item in items" :key="item.title" :to="item.router">
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-list-group :value="true" prepend-icon="mdi-account-circle">
        <template v-slot:activator>
          <v-list-item-title>我的权限</v-list-item-title>
        </template>
        <v-list-item v-for="(items, i) in cruds" :key="i" :to="items.router">
          <v-list-item-title v-text="items.title"></v-list-item-title>

          <v-list-item-icon>
            <v-icon v-text="items.icon"></v-icon>
          </v-list-item-icon>
        </v-list-item>
      </v-list-group>
    </v-list>
  </v-card>
</template>
<script>
import userApi from "@/api/userApi";
export default {
  data() {
    return {
      actions: [],
      cruds: [],
      items: [
        { title: "主页", icon: "mdi-view-dashboard", router: "/index" },
        // { title: "用户管理", icon: "mdi-account-box", router: "/user" },
        // { title: "角色管理", icon: "mdi-gavel", router: "/role" },
        // { title: "权限管理", icon: "mdi-lock", router: "/action" },
      ],
    };
  },
  created() {
    this.initialize();
  },
  methods: {
    initialize() {
      var user = JSON.parse(localStorage.getItem("user"));
      userApi.getActionByUserId(user.Id).then((resp) => {
        const response=resp.data;
        this.actions = response;

        for (var i = 0; i < this.actions.length; i++) {
          var mydata = {
            title: "",
            icon: "mdi-view-dashboard",
            router: "/index",
          };
          mydata.title = this.actions[i].action_name;
          mydata.icon = this.actions[i].icon;

          if (
            this.actions[i].Id == 1 ||
            this.actions[i].Id == 2 ||
            this.actions[i].Id == 3
          ) {
            mydata.router = this.actions[i].router;
            this.items.push(mydata);
          } else {
            var data1 = this.actions[i].router.substring(0, 4);
            var data2 = this.actions[i].router
              .substring(4)
              .replace(/\//g, "%2F");
            mydata.router = data1 + data2;
            this.cruds.push(mydata);
          }
        }
      });
    },
  },
};
</script>