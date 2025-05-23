process.env.TZ = "Asia/Kolkata";
const express = require("express");
const path = require("path");
const helmet = require("helmet");
const cors = require("cors");
const rateLimit = require("express-rate-limit");
const cookieParser = require("cookie-parser");
const authenticateToken = require("./server/middlewares/authMiddleware");
const config = require("./server/config");
const moment = require("moment-timezone");

const app = express();

app.set("trust proxy", 1);

const allowedOrigins = [config.FRONTEND_DOMAIN, config.ADMIN_DOMAIN];

const corsOptions = {
  origin: function (origin, callback) {
    // If no origin or if origin is allowed, then allow the request
    if (!origin || allowedOrigins.indexOf(origin) !== -1) {
      callback(null, true);
    } else {
      callback(new Error("Not allowed by CORS"));
    }
  },
  credentials: true,
  optionsSuccessStatus: 200,
};

app.use(cors(corsOptions));
app.use(mongoSanitize());
app.use(express.urlencoded({ limit: "50mb", extended: true }));
app.use(cookieParser());

// Rate limiting
//   windowMs: 15 * 60 * 1000, // 15 minutes
//   max: 100, // limit each IP to 100 requests per windowMs
// app.use(limiter);


// Connect to MongoDB
mongoose.connect(MONGODB_URI, {
  dbName: config.MONGODB_DB,
});
mongoose.connection.on("connected", () => {
});
mongoose.connection.on("error", (err) => {
  console.error("MongoDB connection error:", err);
});

const now = moment();
console.log("Current Timezone:", process.env.TZ);

// routes
app.use(trackVisitor);
app.use("/api/v1/booking", require("./server/Routers/public/booking"));
app.use("/api/v1/contact", require("./server/Routers/public/contact"));
app.use("/api/v1/payment", require("./server/Routers/public/paymet"));
app.use("/api/v1/study-materials", require("./server/Routers/public/studyMaterials"));
app.use("/api/v1/access-content", require("./server/Routers/public/access-data"));
app.use("/api/v1/blog", require("./server/Routers/public/blog"));
app.use("/api/v2/auth", require("./server/Routers/admin/auth"));
app.use("/api/v2/admin", require("./server/Routers/admin/admin"));
app.use("/api/v2/employee", require("./server/Routers/admin/employee"));
app.use("/api/v2/manager", require("./server/Routers/admin/manager"));
app.use("/api/v2/payment", require("./server/Routers/admin/payment"));
app.use("/api/v2/attendance", require("./server/Routers/admin/attendance"));
app.use("/api/v2/leave", require("./server/Routers/admin/leave"));
app.use("/api/v2/calendar", require("./server/Routers/admin/calendar"));
app.use("/api/v2/teaching-notes", require("./server/Routers/admin/notes"));
app.use("/api/v2/access-content", require("./server/Routers/admin/access-data"));
app.use("/api/v2/blog", require("./server/Routers/admin/blog"));

app.get("/api/v1/protected", authenticateToken, (req, res) => {
  res.status(200).json({
    message: "You have access to this protected route.",
    user: req.user,
    success: true,
  });
});

  res.sendFile(path.join(__dirname, "./server.html"));
});

// app.use(express.static(path.join(__dirname, "frontend/dist")));
// app.get("*", (req, res) => {
app.listen(PORT, () => {
});

// TODO: half-day leave only admin and manager cam give