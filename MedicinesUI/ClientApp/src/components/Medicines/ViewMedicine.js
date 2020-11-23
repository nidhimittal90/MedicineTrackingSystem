import React from 'react';
function ViewMedicine(props) {
    const {id, medicineName, brandName, expiryDate, price, quantity, notes } =
        (props.location && props.location.item) || {};
    const handleChange = e => {
        var updatedNotes = window.prompt("Notes", notes)
        if (notes != updatedNotes) {
            fetch('medicine/UpdateMedicine/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedNotes)
            })
                .then(response => response.json())
                .then(result => {
                    console.log('Success:', result);
                    redirectToList();
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        }
    }

    const redirectToList = e => {
        props.history.push({
            pathname: '/'
        });
    }



    return (
        <div className="card col-12 mt-2 hv-center">
            <form>
                <div className="form-group text-left">
                    <label htmlFor="medicineName">Medicine Name</label>
                    <label className="form-control" htmlFor="medicineValue">{medicineName}</label>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="brandName">Brand Name</label>
                    <label className="form-control" htmlFor="brandValue">{brandName}</label>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="expiryDate">Expiry Date</label>
                    <label className="form-control" htmlFor="expiryValue">{expiryDate}</label>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="price">Price</label>
                    <label className="form-control" htmlFor="price">{price}</label>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="quantity">Quantity</label>
                    <label className="form-control" htmlFor="quantity">{quantity}</label>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="notes">Notes</label>
                    <label className="form-control" htmlFor="notes" onClick={handleChange}>{notes}</label>
                </div>
                <button name="Back" className="btn btn-primary" onClick={redirectToList} > Back </button>
            </form>
        </div>
        )
}
export default ViewMedicine;