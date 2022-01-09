

export let setLocalStorage = (key, value) => {
    if (value && typeof (value) === 'string') {
        sessionStorage  .setItem(key, value);
    } else {
        sessionStorage.setItem(key, JSON.stringify(value));  
    }
};



export let getLocalStorage = (key) => {
    const data = sessionStorage.getItem(key);
    try {
        return JSON.parse(data);  
    } catch (e) {
        return data;
    }
};



export let clearLocalStorage = (key) => sessionStorage.removeItem(key);