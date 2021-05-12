import Vue from 'vue'
import VueRouter from 'vue-router'
import Layout from '@/components/Layout'
import Index from '@/views/Index'
import user from '@/views/user'
import role from '@/views/role'
import action from '@/views/action'

import login from '@/views/login'
import register from '@/views/register'

import my from '@/views/my'

Vue.use(VueRouter)

const routes = [{
        path: '/login',
        name: 'login',
        component: login
    },
    {
        path: '/register',
        name: 'register',
        component: register
    },
    {
        path: '/',
        name: 'Layout',
        component: Layout,
        redirect: "/index",
        children: [{
                path: "/index",
                name: "Index",
                component: Index
            },
            {
                path: '/user',
                name: 'user',
                component: user
            },
            {
                path: '/role',
                name: 'role',
                component: role
            },
            {
                path: '/action',
                name: 'action',
                component: action
            },
            {
                path: '/my/:mylink',
                name: 'my',
                component: my
            }
        ]
    }
]

const router = new VueRouter({
    // mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router