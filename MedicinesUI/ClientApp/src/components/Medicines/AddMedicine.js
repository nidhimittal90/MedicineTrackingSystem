import React, { useState } from 'react';
import axios from 'axios';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const AddMedicine = (props) => {
    const [state, setState] = useState({
        medicineName : "",
        brandName : "",
        expiryDate: "",
        quantity: "",
        price:"",
        notes:""
    });
    const [startDate, setStartDate] = useState(new Date());

    const handleChange = (e) => {
        const { id, value } = e.target;
        setState(prevState => ({
            ...prevState, [id] : value
        }))
    }

    const handleSubmitClick = (e) => {
        e.preventDefault();
            sendDetailsToServer()
    }

    const sendDetailsToServer = () => {
        const payload = {
            "MedicineName": state.medicineName,
            "BrandName": state.brandName,
            "Price": parseFloat(state.price),
            "Quantity": parseInt(state.quantity),
            "Notes": state.notes,
            "ExpiryDate": startDate
        }
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        };
        fetch('medicine/AddMedicine', requestOptions)
                .then(function (response) {
                    if (response.status === 200) {
                        setState(prevState => ({
                            ...prevState,
                            'successMessage': 'Registration successful. Redirecting to home page..'
                        }))
                        redirectToList();
                    } else {
                    }
                })
                .catch(function (error) {
                    console.log(error);
                });
    } 

    const IsValidExpiryDate = date => {
        const diffTime = Math.abs(date - new Date());
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
        if (diffDays <= 30) {
            alert('Expiry date is less than 30 days');
        }
        setStartDate(date);
    }

    const redirectToList= e =>{
        props.history.push({
            pathname: '/'
        });

    }

    return (
        <div className="card col-12 mt-2 hv-center">
            <form>
                <div className="form-group text-left">
                    <label htmlFor="medicineName">Medicine Name</label>
                    <input type="text"
                        className="form-control"
                        id="medicineName"
                        placeholder="Enter medicine name"
                        value={state.medicineName}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="brandName">Brand name</label>
                    <input type="text"
                        className="form-control"
                        id="brandName"
                        placeholder="brand name"
                        value={state.brandName}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="expiryDate">Expiry Date</label>
                    <div>
                        <DatePicker className="form-control" selected={startDate} onChange={date => IsValidExpiryDate(date)}/*{date => setStartDate(date)}*/ />
                    </div>
                </div>
                <div className="form-group text-left">
                    <label htmlFor="price">Price</label>
                    <input type="text"
                        className="form-control"
                        id="price"
                        placeholder="price"
                        value={state.price}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="quantity">Quantity</label>
                    <input type="text"
                        className="form-control"
                        id="quantity"
                        placeholder="quantity"
                        value={state.quantity}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group text-left">
                    <label htmlFor="notes">Notes</label>
                    <input type="textarea"
                        className="form-control"
                        id="notes"
                        placeholder="Notes"
                        value={state.notes}
                        onChange={handleChange}
                    />
                </div>
                <button
                    type="submit"
                    className="btn btn-primary"
                    onClick={handleSubmitClick}
                >
                    Add
                </button>
                <button name="Back" className="dds__btn dds__btn-link" onClick={redirectToList} > Back </button>
            </form>
        </div>
        )
}
export default AddMedicine