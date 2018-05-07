Blazor.registerFunction('blazor_summernote', (id) => {
    $('#' + id).summernote({
        placeholder: 'Content',
        tabsize: 2,
        height: 600
    });
    return true;
});

Blazor.registerFunction('blazor_summernoteCode', (id) => {
    if ($('#' + id) != null) {
        return $('#' + id).summernote('code');
    }
    else {
        return '';
    }
});

Blazor.registerFunction('blazor_summernoteDestroy', (id) => {
    $('#' + id).summernote('destroy');
    return true;
});

Blazor.registerFunction('blazor_localStorageGetValue', (key) => {
    return localStorage.getItem(key);
});

Blazor.registerFunction('blazor_localStorageSetValue', (key, value) => {
    localStorage.setItem(key, value);
    return true;
});