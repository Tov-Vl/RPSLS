import { useEffect, useState } from 'react';
import LoadingSpinner from './LoadingSpinner'

export default function LoadingDelayedSpinner({ delay }) {
    const [showSpinner, setShowSpinner] = useState();

    useEffect(() => {
        const timer = setTimeout(
            () => setShowSpinner(true),
            delay === undefined ? 750 : delay
        );

        return () => clearTimeout(timer);
    }, [delay]);

    return showSpinner && <LoadingSpinner />;
}