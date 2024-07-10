const createInvoice = (invoiceItems) => new Vue({
    el: '#invoiceApp',
    data: {
        invoiceItems
    },
    methods: {
        addItem: function (event) {
            event.preventDefault();
            this.invoiceItems.push({Description: '', Quantity: 1, UnitPrice: 0.00});
            
        },
        removeItem: function (event, index) {
            event.preventDefault();
            this.invoiceItems.splice(index, 1);
        }
    }
});