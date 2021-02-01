import React, { useState, useEffect } from 'react';

export const GetBoatsData = () => {

    const [data, setData] = useState('');


    const populateBoatsData = async () => {
        const response = await fetch('boat');
        const data = await response.json();

        setData(JSON.stringify(data));
    }

    useEffect(() => {
        populateBoatsData();
    }, []);
    return (
        <div><h3>Raw Boats Data</h3>
            <div> {data}</div>
        </div>
    );

}
