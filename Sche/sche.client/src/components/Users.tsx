import { useState } from 'react';

export function Users() {
    const [input, setInput] = useState('dffddf');
    return <input value={input} onChange={e => setInput(e.target.value)}/>;
}