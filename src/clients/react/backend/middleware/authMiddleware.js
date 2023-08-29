import jwt from 'jsonwebtoken';
import asyncHandler from './asyncHandler.js';
import User from '../models/userModel.js';

// Protect Routes

const protect = asyncHandler(async (req, res, next) => {
  let token;

  // Read JWT from cookie
  token = req.cookies.jwt;

  if (token) {
    try {
      // Verify JWT
      const decoded = jwt.verify(token, process.env.JWT_SECRET);
      // Get user from DB
      req.user = await User.findById(decoded.userId).select('-password');
      next();
    } catch (err) {
      res.status(401);
      throw new Error('Not authorized, token failed');
    }
  } else {
    res.status(401);
    throw new Error('Not authorized, no token');
  }
});

// Admin middleware

const admin = (req, res, next) => {
  if (req.user && req.user.isAdmin) {
    next();
  } else {
    res.status(401);
    throw new Error('Not authorized as admin');
  }
};

export { protect, admin };
