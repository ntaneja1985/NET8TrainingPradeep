jQuery.validator.addMethod("codevalidator", function (val, ele, param) {
    if (val != '' && val.indexOf(param.char) == -1) {
        return false;
    } else {
        return true;
    }
})

jQuery.validator.unobtrusive.adapters.add("codevalidator", ["char"], function (option) {
    option.rules['codevalidator'] = { char: option.params.char };
    option.messages['codevalidator'] = option.message;
})