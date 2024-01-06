
$(document).ready(function () {    
    $('#btn-create-bundle').on('click', onBtnCreateBundleClick);     
    $('#btn-insert-product').on('click', onBtnInsertProductClick);
});

const onBtnCreateBundleClick = () => {
    const _name = $('#name').val();
    const _description = $('#description').val();
    const payload = {
        Name: _name,
        Description: _description,
        ChildProducts: []
    }

    const selectedProducts = $('.selected-product-item');
    selectedProducts.each((index, element) => {        
        payload.ChildProducts.push({
            ProductId: parseInt($(element).attr('data-product-id')),
            ProductAmount: parseInt($(element).attr('data-product-amount'))
        });
    });

    console.log('payload', payload);

    showLoading();
    $.post(urlAddBundle, payload, handleAddBundleResponse);
}

const handleAddBundleResponse = (result) => {    
    if (result?.success) {        
        location.href = urlHome;
    }
    else {
        alert('Error');
    }
}

const showLoading = () => {
    $('.form-wrapper').addClass('d-none');
    $('.loading').removeClass('d-none');
}

const onBtnInsertProductClick = () => {       
    // remove message 'no products selected' if necessary
    if ($('.selected-product-item').length === 0) {        
        $('#selected-products').empty();
    }
    // add selected product element
    const productId = $('#drop-down-select-product').val();
    const productName = $('#drop-down-select-product option:selected').text();
    const productAmount = $('#input-inform-product-amount').val();
    if (productId != '-1') {
        const element = `
            <div class="selected-product-item" data-product-id="${productId}" data-product-amount="${productAmount}">
                ${productName} (${productAmount})
            </div>`;
        $('#selected-products').append(element);
    }    
}