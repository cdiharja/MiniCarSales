import React, { useState, useEffect } from 'react';

export const GetCarsData = () => {

    const [data, setData] = useState('');

    const populateCarsData = async () => {
        const response = await fetch('car');
        const data = await response.json();
        setData(JSON.stringify(data));
    }

    useEffect(() => {
        populateCarsData();
    }, []);
    return (
        <div><h3>Raw Cars Data</h3>
            <div> {data}</div>
        </div>
    );

}
