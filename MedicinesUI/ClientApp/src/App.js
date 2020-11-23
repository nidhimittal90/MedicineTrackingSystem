import React, { useState } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import  Header  from './components/Header';
import AddMedicine  from './components/Medicines/AddMedicine';
import MedicineList from './components/Medicines/MedicineList';
import ViewMedicine from './components/Medicines/ViewMedicine';
import ErrorPage from './components/ErrorPage';
import './custom.css'

function App() {
    const [title, updateTitle] = useState(null);

    return (
        <Layout>
            <div className="App">
                <Header title={title} />
                <Route exact path='/' component={MedicineList} updateTitle={updateTitle} />
                <Route path='/addmedicine' component={AddMedicine} updateTitle={updateTitle} />
                <Route path='/medicinelist' component={MedicineList} updateTitle={updateTitle} />
                <Route path='/viewmedicine' component={ViewMedicine} updateTitle={updateTitle} />
            </div>
        </Layout>
    );
}

export default App
