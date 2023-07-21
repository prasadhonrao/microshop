import { useEffect, useState } from 'react';

import { Row, Col } from 'react-bootstrap';
import Product from '../../components/product/Product';

import axios from 'axios';

const HomePage = () => {

  const [products, setProducts] = useState([]);

  useEffect(() => {
    const fetchProducts = async () => {
      const {data} = await axios.get('/api/products');

      // Note: You can also use fetch() instead of axios
      // const res = await fetch('/api/products');
      // const data = await res.json();
      
      setProducts(data);
    }
    fetchProducts();
  }, []);

  return (
    <>
        <h1>Latest Products</h1>
        <Row>
            {products.map(product => (
                <Col key={product.id} sm={12} md={6} lg={4} xl={3}>
                    <Product product={product} />
                </Col>
            ))}
        </Row>
    </>
  )
}

export default HomePage