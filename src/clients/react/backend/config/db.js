import mongoose from 'mongoose';

const connectDB = async () => {
    try {
        const uri = process.env.MONGO_URI;

        // Add "microshop" as the database name in the connection URI
        const conn = await mongoose.connect(process.env.MONGO_URI, {
            useNewUrlParser: true,
            useUnifiedTopology: true,
        });
    
        console.log(`MongoDB Connected: ${conn.connection.host}`);
    
        // Specify the collection name
        const collectionName = 'products';
    
        // Access the "products" collection in the "microshop" database
        const db = conn.connection.db;
        const productCount = await db.collection(collectionName).countDocuments();
        console.log(`Number of products in the collection: ${productCount}`)

    } catch (error) {
        console.log(`Error connecting to MongoDB: ${error}`);
        process.exit(1);
    }
};

export default connectDB;