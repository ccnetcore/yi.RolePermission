import myaxios from '@/utils/myaxios'
export default {
    getAllUser() {
        return myaxios({
            url: '/User/getAllUser',
            method: 'get'
        })
    },
    addUser(user) {
        return myaxios({
            url: '/User/addUser',
            method: 'post',
            data: user
        })
    },
    delUser(userId) {
        return myaxios({
            url: `/User/delUser?userId=${userId}`,
            method: 'get'
        })
    },
    updateUser(user) {
        return myaxios({
            url: '/User/updateUser',
            method: 'post',
            data: user
        })
    },
    delAllUser(Ids) {
        return myaxios({
            url: '/User/delAllUser',
            method: 'post',
            data: Ids
        })
    },
    setRole(Id, Ids) {
        return myaxios({
            url: '/User/setRole',
            method: 'post',
            data: { "Id": Id, "Ids": Ids }
        })
    },
    getRoleByuserId(userId) {
        return myaxios({
            url: `/User/getRoleByuserId?userId=${userId}`,
            method: 'get'
        })
    },
    getSpecialAction(userId) {
        return myaxios({
            url: `/User/getSpecialAction?userId=${userId}`,
            method: 'get'
        })
    },
    setSpecialAction(Id, Ids) {
        return myaxios({
            url: '/User/setSpecialAction',
            method: 'post',
            data: { "Id": Id, "Ids": Ids }
        })
    },
    getActionByUserId(userId) {
        return myaxios({
            url: `/User/getActionByUserId?userId=${userId}`,
            method: 'get'
        })
    }

}