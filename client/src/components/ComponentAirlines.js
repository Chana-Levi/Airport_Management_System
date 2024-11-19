import React, { useEffect, useState } from 'react';
import { getItems } from '../apiAirlines'; // ייבוא הפונקציה הנכונה מהשירותים

export default function ComponentAirlines() {

    const [items, setItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const result = await getItems();
                setItems(result);
            } catch (error) {
                console.error('Error fetching items:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div>
            <h1>ComponentAirlines</h1>
            <ul>
                {items.map(item => (
                    <li key={item.airlineId}>{item.airlineName}</li>
                ))}
            </ul>
        </div>
    );
}
