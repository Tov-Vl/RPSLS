import Home from "./components/Home";
import Scoreboard from "./components/Scoreboard";
import Rules from "./components/Rules";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/scoreboard',
        element: <Scoreboard />
    },
    {
        path: '/rules',
        element: <Rules />
    }
];

export default AppRoutes;
