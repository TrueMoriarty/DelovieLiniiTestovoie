import React, { useEffect, useState } from 'react';
import axios from 'axios';

const RepairTable = () => {
    const [repairData, setRepairData] = useState(null);
    const [date, setDate] = useState('2025-05-01');  // Начальная дата

    useEffect(() => {
        // Формируем URL с параметрами для GET-запроса
        const fetchData = async () => {
            try {
                const response = await axios.get(
                    `http://localhost:5180/api/repair?sort=${date}&currentDate=${date}`
                );
                setRepairData(response.data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, [date]);  // Запрос выполняется при изменении даты

    if (!repairData) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            {/* Ввод даты */}
            <label htmlFor="dateInput">Select Date:</label>
            <input
                type="date"
                id="dateInput"
                value={date}
                onChange={(e) => setDate(e.target.value)}  // Обновляем дату при изменении
            />

            {/* Таблица для RepairResponses */}
            <h2>Repair Responses</h2>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Malfunction</th>
                        <th>Cost</th>
                        <th>Repair Begin</th>
                        <th>Repair End</th>
                        <th>Brand</th>
                    </tr>
                </thead>
                <tbody>
                    {repairData.repairResponses.map((repair) => (
                        <tr key={repair.id}>
                            <td>{repair.id}</td>
                            <td>{repair.malfunction}</td>
                            <td>{repair.cost}</td>
                            <td>{new Date(repair.repairBegin).toLocaleDateString()}</td>
                            <td>{new Date(repair.repairEnd).toLocaleDateString()}</td>
                            <td>{repair.brand}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {/* Таблица для MasterPercentageResponses */}
            <h2>Master Percentage Responses</h2>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Patronymic</th>
                        <th>Repair Begin</th>
                        <th>Repair End</th>
                        <th>Workload</th>
                    </tr>
                </thead>
                <tbody>
                    {repairData.masterPercentageResponses.map((master) => (
                        <tr key={master.name + master.surname}>
                            <td>{master.name}</td>
                            <td>{master.surname}</td>
                            <td>{master.patronymic}</td>
                            <td>{new Date(master.repairBegin).toLocaleDateString()}</td>
                            <td>{new Date(master.repairEnd).toLocaleDateString()}</td>
                            <td>{master.percentageMasterWorkload}%</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default RepairTable;