import myaxios from '@/utils/myaxios'
export default {
    getActions() {
        return myaxios({
            url: '/Action/getActions',
            method: 'get'
        })
    },
    addAction(action) {
        return myaxios({
            url: '/action/addAction',
            method: 'post',
            data: action
        })
    },
    delAction(actionId) {
        return myaxios({
            url: `/action/delAction?actionId=${actionId}`,
            method: 'get'
        })
    },
    updateAction(action) {
        return myaxios({
            url: '/action/UpdateAction',
            method: 'post',
            data: action
        })
    },
    delAllAction(Ids) {
        return myaxios({
            url: '/action/DelAllAction',
            method: 'post',
            data: Ids
        })
    },
}