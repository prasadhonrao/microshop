import express from 'express';
import dotenv from 'dotenv';
import products from './data/products.js';

dotenv.config();
const port = process.env.PORT || 5000;

const app = express();

app.get('/', (req, res) => {
  res.send('API is running...');
});

app.get('/api/products', (req, res) => {
    res.send(products);
});

app.get('/api/products/:id', (req, res) => {
    console.log(req.params.id);
    const product = products.find(product => product._id === req.params.id);
    res.json(product);
});

app.listen(port, () => {`Server listening on port ${port}!`});