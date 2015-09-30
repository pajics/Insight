Array.prototype.joinProperties = function (selector, separator) {
    if (!separator) {
        separator = ',';
    }
    return this.map(function(el){
        return !separator ? el : el[selector];
    }).join(separator);
};
