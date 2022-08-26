function addCartAlert() {
    Snackbar.show({
        text: 'Thêm vào giỏ hàng thành công',
        textColor: 'white',
        actionText: 'Bỏ qua',
        actionTextColor: 'white',
        backgroundColor: '#004DDA',
    })
}
function addCartFailAlert() {
    Snackbar.show({
        text: 'Thêm vào giỏ hàng THẤT BẠI!',
        textColor: 'white',
        actionText: 'Bỏ qua',
        actionTextColor: 'white',
        backgroundColor: 'red',
    })
}