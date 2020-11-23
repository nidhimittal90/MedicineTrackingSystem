import React, { useState, useEffect } from 'react';
import { withRouter, Redirect } from "react-router-dom";


function MedicineList(props) {
    const [data, setData] = useState([]);
    const [search, setSearch] = useState('');

    useEffect(() => {
        (async () => {
            const response = await fetch('medicine');
            const result = await response.json();
            setData(result);
            console.log('data' + data);
        })();
    }, []);

    const redirectToView = (item) => {
        props.history.push({
            pathname: '/viewmedicine',
            item
        });
    }
    const searchSpace = (event) => {
        let keyword = event.target.value;
        setSearch(keyword);
    }

    return (

        <div>
            <input type="text" className="form-control" placeholder="Enter medicine to be searched" onChange={searchSpace} />

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Medicine Name</th>
                        <th>Brand Name</th>
                        <th>Expiry Date</th>
                        <th>Price</th>
                        <th>Quantity</th>
                        <th>Notes</th>
                    </tr>
                </thead>
                <tbody>
                    {data.filter((item) => {
                        if (search == '')
                            return item
                        else if (item.medicineName.toLowerCase().includes(search.toLowerCase())) {
                            return item
                        }
                    })

                        .map(item =>
                        <tr key={item.id} style={{ backgroundColor: item.quantity <= 15 ? "Yellow" : "none" }} onClick={()=>redirectToView(item)} >
                            <td>{item.medicineName}</td>
                            <td>{item.brandName}</td>
                            <td>{item.expiryDate}</td>
                            <td>{item.price}</td>
                            <td>{item.quantity}</td>
                            <td>{item.notes}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
}
export default withRouter(MedicineList)
