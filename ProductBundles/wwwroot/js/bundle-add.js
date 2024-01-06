
$(document).ready(function () {    
    $('#btn-create-bundle').on('click', onBtnCreateBundleClick);     
    $('#btn-insert-product').on('click', onBtnInsertProductClick);
    $('#btn-insert-child-bundle').on('click', onBtnInsertChildBundleClick);    
});

const onBtnCreateBundleClick = () => {
    const _name = $('#name').val();
    const _description = $('#description').val();
    const payload = {
        Name: _name,
        Description: _description,
        ChildProducts: [],
        ChildBundles: []
    }

    const selectedProducts = $('.selected-product-item');
    selectedProducts.each((index, element) => {        
        payload.ChildProducts.push({
            ProductId: parseInt($(element).attr('data-product-id')),
            ProductAmount: parseInt($(element).attr('data-product-amount'))
        });
    });

    const selectedChildBundles = $('.selected-child-bundle-item');
    selectedChildBundles.each((index, element) => {
        payload.ChildBundles.push({
            BundleId: parseInt($(element).attr('data-child-bundle-id')),
            BundleAmount: parseInt($(element).attr('data-child-bundle-amount'))
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
        hideLoading();
    }
}

const showLoading = () => {
    $('.form-wrapper').addClass('d-none');
    $('.loading').removeClass('d-none');
}

const hideLoading = () => {
    $('.form-wrapper').removeClass('d-none');
    $('.loading').addClass('d-none');
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

const onBtnInsertChildBundleClick = () => {
    // remove message 'No child bundles selected' if necessary
    if ($('.selected-child-bundle-item').length === 0) {
        $('#selected-child-bundles').empty();
    }
    // add child bundle element
    const bundleId = $('#drop-down-select-child-bundle').val();
    const bundleName = $('#drop-down-select-child-bundle option:selected').text();
    const childBundleAmount = $('#input-inform-child-bundle-amount').val();
    if (bundleId != '-1') {
        const element = `
            <div class="selected-child-bundle-item" data-child-bundle-id="${bundleId}" data-child-bundle-amount="${childBundleAmount}">
                ${bundleName} (${childBundleAmount})
            </div>`;
        $('#selected-child-bundles').append(element);
    }
}