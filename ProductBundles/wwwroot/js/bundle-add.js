
$(document).ready(function () {    
    $('#btn-create-bundle').on('click', onBtnCreateBundleClick);     
});

const onBtnCreateBundleClick = () => {
    const _name = $('#name').val();
    const payload = {
        Name: _name
    }
    showLoading();
    $.post(urlAddBundle, payload, handleAddBundleResponse);
}

const handleAddBundleResponse = (result) => {
    console.log('result', result)
}

const showLoading = () => {
    $('.form-wrapper').addClass('d-none');
    $('.loading').removeClass('d-none');
}
