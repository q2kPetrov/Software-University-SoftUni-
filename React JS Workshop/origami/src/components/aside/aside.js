import React from 'react'
import Link from '../link/link'
import styles from './aside.module.css'

const Aside = () => {
    return (
        <aside className={styles.aside}>           
            <Link linkContent={1} type="aside" reff={'https://google.com'} />
            <Link linkContent={2} type="aside" reff={'#'} />
            <Link linkContent={3} type="aside" reff={'#'} />
            <Link linkContent={4} type="aside" reff={'#'} />
            <Link linkContent={5} type="aside" reff={'#'} />
            <Link linkContent={6} type="aside" reff={'#'} />
            
        </aside>
    )
}

export default Aside